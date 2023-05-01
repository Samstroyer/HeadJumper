using System.Text.Json;
using System.Numerics;
using Raylib_cs;
using System.IO;
using System;

static internal class World
{
    // Only add moveable objects - other objects with the json
    static internal List<WorldObject> objects = new()
    {
        new MovingWorldObject(new(400, -60, 200, 20) , 0.08f, new(200, 0)),
    };

    static internal EnemyController ec = new();
    static internal CollectibleController cc = new();
    static internal PortalController pc = new();
    static internal InteractableController ic = new();
    static internal CameraController camc = new(new(Engine.screenDim.X / 2, Engine.screenDim.Y / 2), Player.Position, 0f, 1f);

    internal static float gravity = 0.5f;
    public static Vector2 Border = new(4000, 0);

    internal static void LoadObjects()
    {
        string fileContents = File.ReadAllText("./Level.json");

        List<StaticWorldObject> addedObjects = JsonSerializer.Deserialize<List<StaticWorldObject>>(fileContents);
        objects.AddRange(addedObjects);

        foreach (WorldObject wo in objects)
        {
            wo.LoadColor();
        }
    }

    internal static void Render()
    {
        foreach (WorldObject obj in objects)
        {
            if (obj is MovingWorldObject)
            {
                obj.Move();
                obj.Render();
            }
            else if (obj is StaticWorldObject)
            {
                obj.Render();
            }
        }

        ec.DrawAndUpdateEnemies();
        cc.DrawAndUpdateCollectibles();
        pc.DrawAndUpdatePortals();
        ic.DrawAndUpdateInteractables();
    }

    internal static void DrawBackground()
    {
        int levelWidth = (int)World.Border.X;
        // Could be called aspect ratio?
        int imageUtilization = 200;

        // Base variables
        float gradientFromProgress = Raymath.Lerp(0, 255, Player.Position.X / levelWidth);
        Rectangle src;

        // Draw the sky
        Color c = Raylib.GetImageColor(ImageLib.SkyFade, (int)gradientFromProgress, 0);
        Raylib.ClearBackground(c);

        src = new((float)Raymath.Lerp(0, ImageLib.Background.width - imageUtilization, Player.Position.X / levelWidth * 1.1f), 20, imageUtilization, 140);
        Raylib.DrawTexturePro(ImageLib.DistantBackground, src, new(0, 0, Engine.screenDim.X, Engine.screenDim.Y), new(0, 0), 0f, Color.WHITE);

        src = new((float)Raymath.Lerp(0, ImageLib.Background.width - imageUtilization, Player.Position.X / levelWidth), 20, imageUtilization, 140);
        Raylib.DrawTexturePro(ImageLib.Background, src, new(0, 0, Engine.screenDim.X, Engine.screenDim.Y), new(0, 0), 0f, Color.WHITE);

    }

    internal static (bool, float) Colliding(Vector2 position, Vector2 size)
    {
        // Checks if the player is colliding and then teleporting it
        // Only check the feet, so you don't teleport as hard
        Rectangle player = new(position.X, position.Y + size.Y - 20, size.X, 20);

        foreach (var obj in objects)
        {
            if (Raylib.CheckCollisionRecs(obj.r, player))
            {
                return (true, obj.r.y);
            }
        }

        return (false, 0);
    }

    internal static Vector2 TouchingPlatformSpeed(Vector2 position, Vector2 size)
    {
        // Check one pixel lower than the hitbox, makes it so you dont have to fall into the object to move with it
        Rectangle player = new(position.X, position.Y + size.Y - 20, size.X, 21);

        foreach (var obj in objects)
        {
            if (obj is not MovingWorldObject) continue;

            if (Raylib.CheckCollisionRecs(obj.r, player))
            {
                return obj.GetSpeedChange();
            }
        }

        return new(0, 0);
    }

    internal static bool ShouldFall(Vector2 position, Vector2 size)
    {
        // Rectangle player = new(position.X, position.Y, size.X, size.Y + 1); // +1 so that it checksbelow and not on 
        Rectangle player = new(position.X, position.Y + size.Y - 20, size.X, 21);

        foreach (var obj in objects)
        {
            if (Raylib.CheckCollisionRecs(obj.r, player)) return false;
        }

        return true;
    }

    internal static void CheckEnemyHits()
    {
        for (int i = ec.enemies.Count - 1; i >= 0; i--)
        {
            if (Raylib.CheckCollisionRecs(Player.Hitbox, ec.enemies[i].GetHitbox()))
            {
                Player.LoseHitpoints(ec.enemies[i].Damage);
            }
        }
    }

    internal static void CheckCollectibleHits()
    {
        for (int i = cc.collectibles.Count - 1; i >= 0; i--)
        {
            if (cc.collectibles[i].Colliding())
            {
                cc.collectibles.RemoveAt(i);
            }
        }
    }

    internal static void SetCamera(Player p)
    {
        camc.cam.target = Player.Position + p.CameraMovementLerp();
        camc.cam.zoom = p.Zoom;

        // Overrides the focus, if event happens
        camc.CameraSpecialFocus();
    }
}
