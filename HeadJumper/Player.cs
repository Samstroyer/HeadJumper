using Raylib_cs;
using System.Numerics;

public enum Dir
{
    Left = -1,
    Right = 1
}

public class Player
{
    public Vector2 Position { get; set; }

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
}
