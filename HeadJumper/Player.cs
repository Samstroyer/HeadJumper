using System.Numerics;
using Raylib_cs;

public enum Dir
{
    Left = -5,
    Right = 5,
    None = 0
}

public class Player
{
    public Vector2 Position { get; set; }
    public Vector2 Size { get; set; } = new(10, 10);
    public Vector2 Speed { get; set; } = new(0, 0);

    // Meme
    private bool TouchingGrass = true;

    public float Zoom { get; set; } = 2f;

    public Color C { get; set; } = Color.RED;

    public Dir movement = Dir.None;

    PowerUpController powerUpController;

    public Player()
    {
        Position = new(10, 20);
        powerUpController = new();
    }

    public void Move()
    {
        Speed = new((int)movement, Speed.Y);

        if (Position.Y >= 20 && TouchingGrass)
        {
            Speed = new(Speed.X, 0);
            TouchingGrass = true;
        }
        else
        {
            Speed += new Vector2(0, World.gravity);

            if (Position.Y >= 20) { TouchingGrass = true; Position = new(Position.X, 20); }
        }

        Position += Speed;

        // Do not keep constant speed
        movement = Dir.None;

    }

    public void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, 5, 5, Color.GREEN);
    }

    public void Jump()
    {
        if (!TouchingGrass) return;

        Speed = new(Speed.X, -10);
        TouchingGrass = false;
    }
}
