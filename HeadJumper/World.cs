using System.Numerics;
using Raylib_cs;
using System;

static internal class World
{
    static internal List<WorldObject> objects = new()
    {
        new WorldObject(new(-100, 30, 500, 30)),
        new WorldObject(new(-600, 50, 500, 30)),
        new WorldObject(new(500, 30, 500, 30)),
        new WorldObject(new(900, 50, 500, 30)),
    };
    static internal EnemyController ec = new();

    internal static float gravity = 0.5f;


    internal static void Render()
    {
        foreach (WorldObject o in objects)
        {
            o.Render();
        }
    }

    internal static (bool, int) Colliding(Vector2 position, Vector2 size)
    {
        Rectangle player = new(position.X, position.Y, size.X, size.Y);

        foreach (var obj in objects)
        {
            if (Raylib.CheckCollisionRecs(obj.R, player))
            {
                return (true, (int)obj.R.y);
            }
        }

        return (false, 0);
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

    internal static void CheckEnemyHits(Rectangle player)
    {
        for (int i = ec.enemies.Count - 1; i >= 0; i--)
        {
            if (Raylib.CheckCollisionRecs(player, ec.enemies[i].GetHitbox()))
            {
                ec.enemies.RemoveAt(i);
            }
        }
    }
}
