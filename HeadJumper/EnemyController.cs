using Raylib_cs;
using System;

internal class EnemyController
{
    internal List<Enemy> enemies = new();

    internal EnemyController()
    {
        enemies = new()
        {
            new Spike(new(100, 0)),
            new Slime(new(200, -30)),
        };
    }

    internal void DrawAndUpdateEnemies()
    {
        foreach (Enemy e in enemies)
        {
            e.UpdateAndDraw();
        }
    }

    // internal void CheckEnemyHits()
    // {
    //     for (int i = enemies.Count - 1; i >= 0; i--)
    //     {
    //         if (enemies[i].Colliding())
    //         {
    //             Player.LoseHitpoints(enemies[i].Damage);
    //         }
    //     }
    // }
}
