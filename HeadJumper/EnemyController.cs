using Raylib_cs;
using System;

internal class EnemyController
{
    internal List<Enemy> enemies = new();

    internal EnemyController()
    {
        enemies = new()
        {
            new Slime(new(200, -30)),
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
            if (enemies[i].dead) enemies.RemoveAt(i);
            else enemies[i].UpdateAndDraw();
        }
    }
}
