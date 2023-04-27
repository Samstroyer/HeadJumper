using System.Numerics;
using Raylib_cs;

internal class Coin : Collectible
{
    internal Coin(Vector2 pos)
    {
        position = pos;
        size = new(10, 10);
        hitbox = new(position.X, position.Y, size.X, size.Y);
    }

    internal void Render()
    {
        base.Render(ImageLib.Coin);
    }
}
