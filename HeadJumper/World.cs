using System.Numerics;
using Raylib_cs;
using System.IO;
using System;

static internal class World
{
    // Only add moveable objects
    static internal List<WorldObject> objects = new()
    {
        new MovingWorldObject(new(400, -60, 200, 20) , 0.08f, new(200, 0)),
    };

    static internal EnemyController ec = new();
    static internal CollectibleController cc = new();

    internal static float gravity = 0.5f;

    internal static void LoadObjects(List<StaticWorldObject> addedObjects)
    {
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
    }

    internal static void DrawBackground()
    {
        int levelWidth = 3000;
        // Could be called aspect ratio?
        int imageUtilization = 150;

        // Base
        float dist = Raymath.Lerp(0, 255, Player.Position.X / levelWidth);
        Color c = Raylib.GetImageColor(ImageLib.SkyFade, (int)dist, 0);
        Raylib.ClearBackground(c);

        Rectangle src = new((float)Raymath.Lerp(0, ImageLib.Background.width - imageUtilization, Player.Position.X / levelWidth * 1.1f), 20, imageUtilization, 140);
        Rectangle dest = new(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        // Raylib.DrawTexturePro(ImageLib.Background, src, dest, new(0, 0), 0f, Color.WHITE);
        Raylib.DrawTexturePro(ImageLib.DistantBackground, src, dest, new(0, 0), 0f, Color.WHITE);

        src = new((float)Raymath.Lerp(0, ImageLib.Background.width - imageUtilization, Player.Position.X / levelWidth), 20, imageUtilization, 140);
        dest = new(0, 0, Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        // Raylib.DrawTexturePro(ImageLib.Background, src, dest, new(0, 0), 0f, Color.WHITE);
        Raylib.DrawTexturePro(ImageLib.Background, src, dest, new(0, 0), 0f, Color.WHITE);

    }

    internal static (bool, float) Colliding(Vector2 position, Vector2 size)
    {
        Rectangle player = new(position.X, position.Y, size.X, size.Y);

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
        foreach (var obj in objects)
        {
            if (obj is not MovingWorldObject) continue;

            Rectangle player = new(position.X, position.Y, size.X, size.Y + 1); // +1 so that it checksbelow and not on 

            if (Raylib.CheckCollisionRecs(obj.r, player))
            {
                return obj.GetSpeedChange();
            }

        }

        return new(0, 0);
    }

    internal static bool ShouldFall(Vector2 position, Vector2 size)
    {
        Rectangle player = new(position.X, position.Y, size.X, size.Y + 1); // +1 so that it checksbelow and not on 

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
}
