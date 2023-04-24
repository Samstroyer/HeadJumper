using Raylib_cs;
using System;

internal class EnemyController
{
    internal List<Enemy> enemies = new();

    internal EnemyController()
    {
        enemies = new()
        {
            new StationaryEnemy() { Position = new(100, 10) },
            new StationaryEnemy() { Position = new(200, -10) }
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
