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
    internal static readonly float maxHealth = 100;
    internal static float hitPoints = maxHealth;
    internal static Vector2 Position;
    internal static int kills = 0;

    internal static Rectangle Hitbox
    {
        get
        {
            return new Rectangle(Position.X, Position.Y, 50, 50);
        }
    }

    internal Vector2 Size { get; set; } = new(Hitbox.width, Hitbox.height);
    internal Vector2 Speed = new(0, 0);

    private int textureNumber = 0;
    private Texture2D spriteSheetFullHealth = Raylib.LoadTexture("Sprites/PlayerSpriteSheet.png");
    private Texture2D spriteSheetHalfHealth = Raylib.LoadTexture("Sprites/PlayerSpriteSheet.png");
    private Texture2D spriteSheetLowHealth = Raylib.LoadTexture("Sprites/PlayerSpriteSheet.png");
    private Texture2D damageSprite = Raylib.LoadTexture("Sprites/DamagedCharacter.png");

    private System.Timers.Timer spriteTimer = new(200)
    {
        AutoReset = true,
        Enabled = true,
    };

    private static System.Timers.Timer damageReset = new(500)
    {
        AutoReset = false,
        Enabled = true,
    };

    // Meme - but usefull
    private bool TouchingGrass = true;

    internal float Zoom { get; set; } = 1.5f;

    private Vector2 zoomMinMax = new(1.5f, 0.5f);
    private float cameraLerp = 0;

    internal Color C { get; set; } = Color.RED;

    internal Dir movement = Dir.None;
    internal static int coins = 0;
    private static bool canBeDamaged = true;

    internal Player()
    {
        Position = new(40, -100);
        spriteTimer.Elapsed += ChangeSprite;
        damageReset.Elapsed += CanTakeDamage;
    }

    internal static void Heal(int amount)
    {
        hitPoints += amount;
        if (hitPoints > maxHealth) hitPoints = maxHealth;
    }

    internal void MoveAndRender()
    {
        if (PowerUpController.boosts[PowerUps.Speed].isActive) Speed = new((int)movement * 2, Speed.Y);
        else Speed = new((int)movement, Speed.Y);

        if (!TouchingGrass || World.ShouldFall(Position, Size)) { Speed.Y += World.gravity; }

        (bool isColliding, float objectHeight) results = World.Colliding(Position, Size);

        if (results.isColliding)
        {
            Speed.Y = 0;
            Position.Y = results.objectHeight - Size.Y;
            TouchingGrass = true;
        }

        // Add the speed of a moving platform
        Speed += World.TouchingPlatformSpeed(Position, Size);

        Position += Speed;

        // World Borders
        if (Position.X < 0) Position.X = 0;
        else if (Position.X > World.Border.X - Player.Hitbox.width) Position.X = World.Border.X - Player.Hitbox.width;

        Draw();
    }

    internal void Controls()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) Jump();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement = Dir.Left;
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement = Dir.Right;
        else movement = Dir.None;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_Z)) Zooming(true);
        else Zooming(false);
    }

    private void ChangeSprite(Object source, ElapsedEventArgs e)
    {
        textureNumber++;
    }

    private void CanTakeDamage(Object source, ElapsedEventArgs e)
    {
        canBeDamaged = true;
    }

    private void Draw()
    {
        // TODO // Determine HP and use correct sprite with function here

        if (!canBeDamaged)
        {
            Rectangle playerRec = new((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            Raylib.DrawTexturePro(damageSprite, new(0, 0, 40, 40), playerRec, new(0, 0), 0f, Color.WHITE);
        }
        else
        {
            int spriteHeight = 0;

            if (!TouchingGrass) spriteHeight = 2;
            else
            {
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
            }

            Rectangle playerRec = new((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            Raylib.DrawTexturePro(spriteSheetFullHealth, new((textureNumber %= 3) * 40, spriteHeight * 40, 40, 40), playerRec, new(0, 0), 0f, Color.WHITE);
        }

        // Hitbox - for debugging
        // Raylib.DrawRectangleRec(playerRec, Color.RED);
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

    internal Vector2 LookAhead()
    {
        if (movement == Dir.None) return new(0, 0);
        else return new((int)movement * 10, 0);

        // if (movement == Dir.None) { cameraLerp = Raymath.Lerp(cameraLerp, 0 + Size.X / 2, 0.1f); }
        // else cameraLerp = Raymath.Lerp(cameraLerp, (int)movement * 10, 0.1f);

        // return new(cameraLerp, 0);
    }

    internal static void DrawHUD()
    {
        Raylib.DrawTexturePro(ImageLib.HUDElement, new(0, 0, ImageLib.HUDElement.width, ImageLib.HUDElement.height), new(0, 0, ImageLib.HUDElement.width, ImageLib.HUDElement.height), new(0, 0), 0f, Color.WHITE);
        DrawHPStats();
        DrawCoinStats();
    }

    private static void DrawCoinStats()
    {
        Raylib.DrawTexture(ImageLib.Coin, 800, 10, Color.WHITE);

        int width = Raylib.MeasureText($"{coins}", 20);
        Raylib.DrawText($"{coins}", 820 - width / 2, 22, 20, Color.BLACK);
    }

    private static void DrawHPStats()
    {
        Raylib.DrawTexture(ImageLib.Heart, 600, 10, Color.WHITE);
        Raylib.DrawText($"HP:{hitPoints}", 600, 55, 20, Color.BLACK);

        // Calculate height of HP bar (with percentage)
        float hpPercentage = hitPoints / maxHealth;
        Rectangle hpBar = new(650, 10 + ((1 - hpPercentage) * 40), 10, hpPercentage * 40);

        Raylib.DrawRectangle(650, 10, 10, 40, Color.GRAY);
        Raylib.DrawRectangleRec(hpBar, Color.RED);
    }

    internal static void LoseHitpoints(int amount)
    {
        if (canBeDamaged)
        {
            hitPoints -= amount;
            canBeDamaged = false;
            damageReset.Start();
        }
    }
}
