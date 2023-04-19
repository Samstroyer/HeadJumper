using System.Numerics;
using Raylib_cs;

internal abstract class Enemy
{
    internal int Speed { get; set; }
    internal int Damage { get; set; }
    internal int Hitpoints { get; set; }
    internal Vector2 Position { get; set; }

    internal virtual void Draw()
    {
        Raylib.DrawRectangle((int)Position.X - 5, (int)Position.Y - 10, 10, 10, Color.RED);
    }
}
