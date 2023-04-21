using System.Numerics;
using Raylib_cs;

internal abstract class Enemy
{
    internal int Speed { get; set; }
    internal int Damage { get; set; }
    internal int Hitpoints { get; set; }
    internal Vector2 Position { get; set; }
    internal Vector2 Size { get; set; } = new(10, 10);

    internal virtual void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y, Color.RED);
    }
}
