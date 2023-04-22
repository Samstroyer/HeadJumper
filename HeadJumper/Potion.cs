using System.Numerics;
using Raylib_cs;

internal class Potion : Collectible
{
    internal Potion(Vector2 pos)
    {
        position = pos;
    }

    internal override void Render()
    {
        base.Render();
    }
}
