using System.Numerics;
using System.Timers;
using Raylib_cs;

internal class Slime : Enemy
{
    enum PlayerDir
    {
        left = -1,
        right = 1,
        blind = 0,
    }

    bool touchingGround = true;
    bool ready = true;

    private System.Timers.Timer jumpCooldown;
    private System.Timers.Timer spriteTimer;

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
        spriteTimer = new(200)
        {
            AutoReset = true,
            Enabled = true,
        };

        jumpCooldown = new(2000)
        {
            AutoReset = false,
            Enabled = true,
        };

        spriteTimer.Elapsed += ChangeSprite;
        jumpCooldown.Elapsed += ReadyToJump;

        spriteTimer.Start();

        Position = pos;
        Size = new(50, 50);
        Speed = new(0, 0);

        Damage = 15;

        hitbox = new(Position.X, Position.Y, Size.X, Size.Y);
    }

    internal override void UpdateAndDraw()
    {
        if (CheckBounds())
        {
            dead = true;
            Player.kills++;
            return;
        }

        if (SeesPlayer())
        {
            Move();
            TryJump();
        }
        else jumpDir = PlayerDir.blind;

        if (touchingGround) Raylib.DrawTexturePro(ImageLib.SlimeSpriteSheet, new(0, 0, 32, 32), hitbox, new(0, 0), 0f, Color.WHITE);
        else Raylib.DrawTexturePro(ImageLib.SlimeSpriteSheet, new(32 * (spriteNum % 8), 0, 32, 32), hitbox, new(0, 0), 0f, Color.WHITE);
    }

    private bool CheckBounds()
    {
        return Position.Y > 200;
    }

    private void Move()
    {
        if (Player.Position.X > Position.X) jumpDir = PlayerDir.right;
        else jumpDir = PlayerDir.left;

        Speed.Y += World.gravity;

        var collisionInfo = World.Colliding(Position, Size);
        if (collisionInfo.Item1)
        {
            Position.Y = collisionInfo.Item2 - Size.Y;
            Speed.Y = 0;
            touchingGround = true;
            jumpDir = PlayerDir.blind;
        }

        Position += Speed;
    }

    private void ChangeSprite(Object source, ElapsedEventArgs e)
    {
        if (touchingGround) spriteNum = 0;
        else spriteNum++;
    }

    private void ReadyToJump(Object source, ElapsedEventArgs e)
    {
        ready = true;
    }

    private void TryJump()
    {
        if (!touchingGround) return;
        if (!ready) return;

        Jump();
    }

    private void Jump()
    {
        touchingGround = false;

        spriteTimer.Stop();

        spriteNum = 0;
        ready = false;

        spriteTimer.Start();

        jumpCooldown.Start();

        Speed = new((int)jumpDir * 5, -10);
        Position += Speed;
    }

    private bool SeesPlayer()
    {
        return Raylib.CheckCollisionRecs(Player.Hitbox, sight);
    }
}
