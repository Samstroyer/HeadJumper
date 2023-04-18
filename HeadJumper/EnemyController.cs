using Raylib_cs;
using System;

public class EnemyController
{
    public List<Enemy> Enemies { get; set; } = new();

    public EnemyController()
    {
        Enemies.Add(new SlowEnemy());
    }

    public void DrawEnemies()
    {
        foreach (Enemy e in Enemies)
        {
            e.Draw();
        }
    }
}
