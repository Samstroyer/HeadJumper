using System.Numerics;
using System.Timers;
using Raylib_cs;

public class Portal
{
    Rectangle Hitbox
    {
        get
        {
            return new(position.X, position.Y, size.X, size.Y);
        }
    }

    Portal exitTo;

    Vector2 position;
    static Vector2 size = new(40, 40);
    static Texture2D PortalSprites = Raylib.LoadTexture("Sprites/PortalSpriteSheet.png");
    int textureNumber = 0;
    private System.Timers.Timer spriteTimer = new(200)
    {
        AutoReset = true,
        Enabled = true,
    };

    static bool canUse = true;
    static private System.Timers.Timer UseTimer = new(2000)
    {
        AutoReset = false,
        Enabled = true,
    };

    private void ChangeSprite(Object source, ElapsedEventArgs e)
    {
        textureNumber++;
    }

    private static void ActivateTravel(Object source, ElapsedEventArgs e)
    {
        canUse = true;
    }

    public Portal(int x, int y)
    {
        position = new(x, y);
        spriteTimer.Elapsed += ChangeSprite;
        UseTimer.Elapsed += ActivateTravel;
    }

    public void LinkTo(Portal p)
    {
        exitTo = p;
    }

    public void TryTravel()
    {
        if (Raylib.CheckCollisionRecs(Player.Hitbox, Hitbox) && canUse)
        {
            Player.Position = exitTo.ExitPosition();
            canUse = false;
            UseTimer.Start();
        }
    }

    private Vector2 ExitPosition()
    {
        return position;
    }

    public void DrawPortal()
    {
        Raylib.DrawTexturePro(PortalSprites, new((textureNumber % 3) * 40, 0, 40, 40), new(position.X, position.Y, size.X, size.Y), new(0, 0), 0f, Color.WHITE);
    }
}
