using Raylib_cs;
using System;

internal class CollectibleController
{
    internal List<Collectible> collectibles = new();

    internal CollectibleController()
    {
        collectibles = new()
        {
            new Coin(new(200, 30)),
            new Coin(new(100, 10)),
        };
    }

    internal void DrawCollectibles()
    {
        foreach (Collectible c in collectibles)
        {
            c.Render();
        }
    }
}
