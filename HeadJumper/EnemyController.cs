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
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i].dead) enemies.RemoveAt(i);
            else enemies[i].UpdateAndDraw();
        }
    }
}
