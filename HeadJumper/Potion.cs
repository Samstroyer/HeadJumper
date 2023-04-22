using System.Numerics;
using Raylib_cs;

internal class Potion : Collectible
{
    internal Potion(Vector2 pos)
    {
        position = pos;
        size = new(20, 20);
        dest = new(position.X, position.Y, size.X, size.Y);
    }

    internal void Render()
    {
        base.Render(ImageLib.HealthPotion);
    }
}
