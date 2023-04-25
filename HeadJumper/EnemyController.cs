using Raylib_cs;
using System;

internal class EnemyController
{
    internal List<Enemy> enemies = new();

    internal EnemyController()
    {
        enemies = new()
        {
            new Spike(new(100, 100)),
        };
    }

    internal void DrawEnemies()
    {
        foreach (Enemy e in enemies)
        {
            e.UpdateAndDraw();
        }
    }
}
