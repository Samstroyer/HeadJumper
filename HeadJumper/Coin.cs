using System.Numerics;
using Raylib_cs;

internal class Coin : Collectible
{
    internal Coin(Vector2 pos)
    {
        position = pos;
    }

    internal override void Render()
    {
        base.Render();
    }
}
