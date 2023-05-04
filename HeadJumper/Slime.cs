using System.Numerics;
using System.Timers;
using Raylib_cs;

internal class Slime : Enemy
{
    enum PlayerDir
    {
        left = -1,
        right = 1,
    }

    bool ready = true;
    bool touchingGround = true;

    private System.Timers.Timer SpriteTimer;

    private int spriteNum = 0;

    Rectangle sight
    {
        get
        {
            float viewRangeRadius = 200;
            float midPointX = Position.X + Size.X;
            float midPointY = Position.Y + Size.Y;
            return new(midPointX - viewRangeRadius, midPointY - viewRangeRadius, viewRangeRadius * 2, viewRangeRadius * 2);
        }
    }

    PlayerDir jumpDir;

    internal Slime(Vector2 pos) : base()
    {
        SpriteTimer = new(200)
        {
            AutoReset = false,
            Enabled = true,
        };

        Position = pos;
        Size = new(50, 50);

        Damage = 15;

        hitbox = new(Position.X, Position.Y, Size.X, Size.Y);
    }

    internal override void UpdateAndDraw()
    {
        if (SeesPlayer() && ready)
        {
            if (Player.Position.X > Position.X) jumpDir = PlayerDir.right;
            Jump();
        }

        if (touchingGround) Raylib.DrawTexturePro(ImageLib.SlimeSpriteSheet, new(0, 0, 32, 32), hitbox, new(0, 0), 0f, Color.WHITE);
    }

    private void ChangeSprite(Object source, ElapsedEventArgs e)
    {
        spriteNum++;
    }

    private void Jump()
    {

    }

    private bool SeesPlayer()
    {
        Raylib.DrawRectangleRec(sight, Color.RED);
        return Raylib.CheckCollisionRecs(Player.Hitbox, sight);
    }
}
