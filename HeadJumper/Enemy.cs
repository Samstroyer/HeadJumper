using System.Numerics;
using Raylib_cs;

public abstract class Enemy
{
    public int Speed { get; set; }
    public int Damage { get; set; }
    public int Hitpoints { get; set; }
    public Vector2 Position { get; set; }

    public virtual void Draw()
    {
        Raylib.DrawRectangle((int)Position.X - 5, (int)Position.Y - 10, 10, 10, Color.RED);
    }
}
