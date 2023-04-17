using Raylib_cs;
using System.Numerics;
using Raylib_cs;

public enum Dir
{
    Left = -1,
    Right = 1
}

public class Player
{
    public Vector2 Position { get; set; }
    public float Zoom { get; set; } = 1;
    public Vector2 Size { get; set; } = new(10, 10);
    public Color C { get; set; } = Color.RED;
    public float Speed { get; set; } = 5;
    public float JumpStart { get; set; } = -10;
    public float JumpChange { get; set; } = 0.05f;

    PowerUpController powerUpController;

    public Player()
    {
        Position = new(10, 10);
        powerUpController = new();
    }

    public void Jump()
    {

    }

    public void Move(Dir direction)
    {
        Position = Position + new Vector2((int)direction, 0);
    }

    public void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 5, 5, Color.GREEN);
    }

    public void Jump()
    {
        Position = Position - new()
    }
}
