using System.Numerics;
using Raylib_cs;

public class Player
{
    public Vector2 Position { get; set; }
    public float Zoom { get; set; } = 1;
    public Vector2 Size { get; set; } = new(10, 10);
    public Color C { get; set; } = Color.RED;
    public float Speed { get; set; } = 5;
    public float JumpStart { get; set; } = -10;
    public float JumpChange { get; set; } = 0.05f;

    public Player()
    {
        Position = new(10, 10);
    }

    public void Jump()
    {
        Position = Position - new()
    }
}
