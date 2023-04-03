using Raylib_cs;
using System;

public class EnemyController
{
    public List<Enemy> Enemies { get; set; } = new();

    public EnemyController()
    {
        Enemies.Add(new SlowEnemy()
        {
            Position = new(100, 0),
            C = Color.RED,
            JumpStrength = 10f,
            Size = new(10, 10),
            Speed = -1f
        });
    }

    public void DrawEnemies()
    {
        foreach (Enemy e in Enemies)
        {
            e.Draw();
        }
    }
}
