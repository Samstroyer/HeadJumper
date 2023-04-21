using Raylib_cs;
using System;

internal class EnemyController
{
    internal List<Enemy> enemies = new();

    internal EnemyController()
    {
        enemies = new() {
            new SlowEnemy() { Position = new(100, 10) },
            new SlowEnemy() { Position = new(-100, 10) }
        };
    }

    internal void DrawEnemies()
    {
        foreach (Enemy e in enemies)
        {
            e.Draw();
        }
    }
}
