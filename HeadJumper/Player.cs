using System.Numerics;
using System.Timers;
using Raylib_cs;

internal enum Dir
{
    Left = -5,
    Right = 5,
    None = 0
}

internal class Player
{
    internal static Vector2 Position { get; set; }

    internal static Rectangle Hitbox
    {
        get
        {
            return new Rectangle(Position.X, Position.Y, 40, 40);
        }
    }

    internal Vector2 Size { get; set; } = new(40, 40);
    internal Vector2 Speed = new(0, 0);

    private int textureNumber = 0;
    private Texture2D spriteSheet = Raylib.LoadTexture("Sprites/PlayerSpriteSheet.png");
    private System.Timers.Timer spriteTimer = new(200)
    {
        AutoReset = true,
        Enabled = true,
    };

    // Meme
    private bool TouchingGrass = true;

    internal float Zoom { get; set; } = 2f;

    private Vector2 zoomMinMax = new(2f, 0.5f);
    private float cameraLerp = 0;

    internal Color C { get; set; } = Color.RED;

    internal Dir movement = Dir.None;
    internal static int coins = 0;

    internal Player()
    {
        Position = new(10, 20);
        spriteTimer.Elapsed += ChangeSprite;
    }

    internal void MoveAndRender()
    {
        if (PowerUpController.boosts[PowerUps.Speed].isActive) Speed = new((int)movement * 2, Speed.Y);
        else Speed = new((int)movement, Speed.Y);

        if (!TouchingGrass || World.ShouldFall(Position, Size)) { Speed.Y += World.gravity; }


        var results = World.Colliding(Position, Size);
        if (results.Item1)
        {
            Speed.Y = 0;
            Position = new(Position.X, results.Item2 - Size.Y);
            TouchingGrass = true;
        }

        Position += Speed;

        Draw();
    }

    private void ChangeSprite(Object source, ElapsedEventArgs e)
    {
        textureNumber++;
        if (textureNumber > 3) textureNumber = 0;
    }

    private void Draw()
    {
        int spriteHeight = 0;

        switch (movement)
        {
            case Dir.Right:
                spriteHeight = 0;
                break;
            case Dir.Left:
                spriteHeight = 1;
                break;
            case Dir.None:
                spriteHeight = 3;
                break;
        }

        if (!TouchingGrass) spriteHeight = 2;

        Rectangle playerRec = new((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        Raylib.DrawTexturePro(spriteSheet, new(textureNumber * 40, spriteHeight * 40, 40, 40), playerRec, new(0, 0), 0f, Color.WHITE);
        // Raylib.DrawRectangleRec(playerRec, new(100, 100, 100, 100));
    }

    internal void Jump()
    {
        if (!TouchingGrass) return;

        if (PowerUpController.boosts[PowerUps.Jump].isActive) Speed = new(Speed.X, -10f * 1.3f);
        else Speed = new(Speed.X, -10);

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
        else cameraLerp = Raymath.Lerp(cameraLerp, (int)movement * 8, 0.1f);

        return new(cameraLerp, 0);
    }

    internal static void DrawStats()
    {
        Raylib.DrawTexture(ImageLib.Heart, 600, 10, Color.WHITE);

        Raylib.DrawTexture(ImageLib.Coin, 700, 10, Color.WHITE);
    }
}
