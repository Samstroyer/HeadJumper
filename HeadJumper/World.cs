using System;

internal class World
{
    List<WorldObjects> objects;
    EnemyController ec;

    internal static float gravity = 0.5f;

    internal World()
    {
        objects = new()
        {
            new WorldObjects()
        };
    }

    internal void Render()
    {
        foreach (WorldObjects o in objects)
        {
            o.Render();
        }
    }
}
