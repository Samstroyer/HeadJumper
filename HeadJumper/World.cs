using System.Numerics;
using Raylib_cs;
using System;

static internal class World
{
    static internal List<WorldObject> objects = new()
    {
        new StaticWorldObject(new(000 , 50 , 300, 30)),
        new StaticWorldObject(new(300 , 30 , 300, 30)),
        new StaticWorldObject(new(600 , 30 , 300, 30)),
        new StaticWorldObject(new(900 , 20 , 50 , 30)),
        new StaticWorldObject(new(950 , 10 , 400, 30)),
        new StaticWorldObject(new(1350, -10, 200, 20)),
        new MovingWorldObject(new(1650, -60, 200, 20) , 0.05f, new(200, 0)),
    };

    static internal EnemyController ec = new();
    static internal CollectibleController cc = new();

    internal static float gravity = 0.5f;


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

    internal static (bool, float) Colliding(Vector2 position, Vector2 size)
    {
        Rectangle player = new(position.X, position.Y, size.X, size.Y);

        foreach (var obj in objects)
        {
            if (Raylib.CheckCollisionRecs(obj.R, player))
            {
                return (true, obj.R.y);
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

            if (Raylib.CheckCollisionRecs(obj.R, player))
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
            if (Raylib.CheckCollisionRecs(obj.R, player)) return false;
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
