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
            new Potion(new(200, -30)),
            new Potion(new(100, -10)),
        };
    }

    internal void DrawCollectibles()
    {
        foreach (Collectible c in collectibles)
        {
            if (c is Potion)
            {
                Potion potion = (Potion)c;
                potion.Render();
                if (potion.Colliding()) Player.Heal();
            }
            else if (c is Coin)
            {
                Coin coin = (Coin)c;
                coin.Render();
                if (coin.Colliding()) Player.coins++;
            }
        }
    }
}
