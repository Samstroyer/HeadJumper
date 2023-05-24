using Raylib_cs;
using System;

internal class EnemyController
{
    internal List<Enemy> enemies = new();

    internal EnemyController()
    {
        enemies = new()
        {
            new Slime(new(1200, 5)),
            new Slime(new(10950, 170)),
            new Slime(new(11000, 170)),
            new Slime(new(11050, 170)),
        };

        for (int i = 0; i < 2200; i += 40)
        {
            enemies.Add(new Spike(new(2717 + i, 77)));
        }
    }

    internal void DrawAndUpdateEnemies()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].dead)
            {
                enemies.RemoveAt(i);
                Player.kills++;
            }
            else enemies[i].UpdateAndDraw();
        }
    }
}
