using System.Numerics;
using Raylib_cs;

internal enum Dir
{
    Left = -5,
    Right = 5,
    None = 0
}

internal class Player
{
    internal Vector2 Position { get; set; }
    internal Vector2 Size { get; set; } = new(10, 10);
    internal Vector2 Speed = new(0, 0);

    // Meme
    private bool TouchingGrass = true;

    internal float Zoom { get; set; } = 2f;

    private Vector2 zoomMinMax = new(2f, 0.5f);
    private float cameraLerp = 0;

    internal Color C { get; set; } = Color.RED;

    internal Dir movement = Dir.None;

    internal Player()
    {
        Position = new(10, 20);
    }

    internal void Move()
    {
        Speed = new((int)movement, Speed.Y);

        if (!TouchingGrass || World.ShouldFall(Position, Size)) { Speed.Y += World.gravity; }


        var results = World.Colliding(Position, Size);
        if (results.Item1)
        {
            Speed.Y = 0;
            Position = new(Position.X, results.Item2 - Size.Y);
            TouchingGrass = true;
        }

        Position += Speed;

        // Do not keep constant speed
        movement = Dir.None;

    }

    internal void Draw()
    {
        Raylib.DrawRectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y, Color.GREEN);
    }

    internal void Jump()
    {
        if (!TouchingGrass) return;

        Speed = new(Speed.X, -10);
        TouchingGrass = false;
    }

    internal void Zooming(bool zoomingOut)
    {
        if (zoomingOut) Zoom = Raymath.Lerp(Zoom, zoomMinMax.Y, 0.1f);
        else Zoom = Raymath.Lerp(Zoom, zoomMinMax.X, 0.1f);
    }

    internal Vector2 CameraMovementLerp()
    {
        if (movement == Dir.None) { cameraLerp = Raymath.Lerp(cameraLerp, 0, 0.1f); }
        else cameraLerp = Raymath.Lerp(cameraLerp, (int)movement * 6, 0.1f);

        return new(cameraLerp, 0);
    }

    internal void Powers()
    {

    }
}
