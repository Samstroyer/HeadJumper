using System;

public class World
{
    List<Platform> Platforms;

    public World()
    {
        Platforms = new()
        {
            new Platform()
        };
    }

    public void Render()
    {
        foreach (Platform p in Platforms)
        {
            p.Render();
        }
    }
}
