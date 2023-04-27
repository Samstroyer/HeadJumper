using System.Numerics;
using Raylib_cs;

internal class Potion : Collectible
{
    internal int healing = 20;

    internal Potion(Vector2 pos, int customHealing)
    {
        healing = customHealing;
        position = pos;
        size = new(20, 20);
        hitbox = new(position.X, position.Y, size.X, size.Y);
    }

    internal Potion(Vector2 pos)
    {
        position = pos;
        size = new(20, 20);
        hitbox = new(position.X, position.Y, size.X, size.Y);
    }

    internal void Render()
    {
        base.Render(ImageLib.HealthPotion);
    }
}
