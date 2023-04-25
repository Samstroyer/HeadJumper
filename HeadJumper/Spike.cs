using System.Numerics;
using Raylib_cs;

internal class Spike : Enemy
{
    internal Spike(Vector2 pos) : base()
    {
        Damage = 10;
        Position = pos;
        Size = new(40, 40);

        hitbox = new(Position.X, Position.Y, Size.X, Size.Y);
    }

    internal override void UpdateAndDraw()
    {
        Raylib.DrawTexturePro(ImageLib.Spikes, new(0, 0, ImageLib.Spikes.width, ImageLib.Spikes.height), hitbox, new(0, 0), 0f, Color.WHITE);
    }

}
