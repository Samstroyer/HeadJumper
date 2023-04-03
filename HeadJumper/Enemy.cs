using System.Numerics;
using Raylib_cs;

public abstract class Enemy
{
    public Vector2 Size { get; set; } = new();
    public Vector2 Position { get; set; } = new();
    public float JumpStrength { get; set; } = new();
    public float Speed { get; set; } = new();
    public Color C { get; set; } = Color.BLUE;

    private Rectangle EnemyRec
    {
        get
        {
            return new(Position.X, Position.Y, Size.X, Size.Y);
        }
        set
        {
            Position = new(value.x, value.y);
            Size = new(value.width, value.height);
        }
    }

    public virtual void Draw()
    {
        Raylib.DrawRectangleRec(EnemyRec, C);
    }

    public void Move()
    {
        Position = Position - new Vector2(Speed, 0);
    }
}
