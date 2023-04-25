using System.Numerics;
using Raylib_cs;

internal abstract class Enemy
{
    internal int Speed { get; set; }
    internal int Damage { get; set; }
    internal int Hitpoints { get; set; }
    internal Vector2 Position;
    internal Vector2 Size = new(10, 10);
    protected Rectangle hitbox;

    internal virtual void UpdateAndDraw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y, Color.RED);
    }

    internal Rectangle GetHitbox()
    {
        hitbox = new(Position.X, Position.Y, Size.X, Size.Y);
        return hitbox;
    }

    internal bool Colliding()
    {
        return Raylib.CheckCollisionRecs(hitbox, Player.Hitbox);
    }
}
