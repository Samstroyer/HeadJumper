using System;

public class World
{
    List<WorldObjects> objects;
    EnemyController ec;

    public static float gravity = 0.5f;

    public World()
    {
        objects = new()
        {
            new WorldObjects()
        };
    }

    public void Render()
    {
        foreach (WorldObjects o in objects)
        {
            o.Render();
        }
    }
}
