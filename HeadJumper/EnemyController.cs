using Raylib_cs;
using System;

internal class EnemyController
{
    internal List<Enemy> Enemies { get; set; } = new();

    internal EnemyController()
    {
        Enemies.Add(new SlowEnemy());
    }

    internal void DrawEnemies()
    {
        foreach (Enemy e in Enemies)
        {
            e.Draw();
        }
    }
}
