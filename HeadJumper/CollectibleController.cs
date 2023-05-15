using Raylib_cs;
using System;
using System.Numerics;

internal class CollectibleController
{
    internal List<Collectible> collectibles = new();
    static Random r = new();

    internal CollectibleController()
    {
        // Maybe load from json?
        collectibles = new()
        {
            new Coin(new(200, 30)),
            new Coin(new(100, 10)),
            new Potion(new(200, -30)),
            new Potion(new(100, -10)),
        };
    }

    internal void AddDropAt(Vector2 position)
    {
        float spawn = r.Next(100);

        if (spawn < 10)
        {
            collectibles.Add(new Potion(position));
            collectibles.Add(new Coin(position));
        }
        else if (spawn < 45)
        {
            collectibles.Add(new Potion(position));
        }
        else if (spawn < 80)
        {
            collectibles.Add(new Coin(position));
        }
    }

    internal void DrawAndUpdateCollectibles()
    {
        foreach (Collectible c in collectibles)
        {
            if (c is Potion)
            {
                Potion potion = (Potion)c;
                potion.Render();
                if (potion.Colliding()) Player.Heal(potion.healing);
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
