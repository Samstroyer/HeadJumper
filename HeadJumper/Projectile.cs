using System.Numerics;
using Raylib_cs;

// Set direction and spawn from Player.Position when activated!

internal class Projectile : BoostInfo
{
    internal int speed;
    internal Vector2 position;
    internal static Direction shootingDir = Direction.right;
    private Rectangle r;

    static Texture2D leftTexture = Raylib.LoadTexture("Sprites/ProjectileFlipped.png");

    internal enum Direction
    {
        left = -3,
        right = 3
    }

    internal Projectile(string name, string info, float cooldown, float timeActive, KeyboardKey activationKey) : base(name, info, cooldown, timeActive, activationKey, Color.BLANK) { }

    internal override void Update()
    {
        if (!isActive) return;
        Move();
        CheckEnemyHits();
        Render();
    }

    private void CheckEnemyHits()
    {
        foreach (Enemy e in World.ec.enemies)
        {
            if (e is Spike) continue;
            if (e is Slime)
            {
                if (Raylib.CheckCollisionRecs(e.GetHitbox(), r))
                {
                    e.dead = true;
                    World.cc.AddDropAt(e.Position);
                }
            }
        }
    }

    private void Move()
    {
        position.X += speed;

        r = new(position.X, position.Y, 40, 40);
    }

    internal override void TryActivate()
    {
        if (!available) return;
        if (isActive) return;

        Shoot();
    }

    private void Shoot()
    {
        isActive = true; available = false;
        activeTimer.Start();
        lastActivated = DateTime.Now.AddSeconds(activeTimer.Interval / 1000);

        speed = (int)shootingDir;
        position = Player.Position + new Vector2(0, 20);
    }

    internal static void ChangeDir()
    {
        if (shootingDir == Direction.left) shootingDir = Direction.right;
        else shootingDir = Direction.left;
    }

    private void Render()
    {
        if (speed > 0) Raylib.DrawTexturePro(boostTexture, new(0, 0, 40, 40), r, new(20, 20), 0f, Color.WHITE);
        else Raylib.DrawTexturePro(leftTexture, new(0, 0, 40, 40), r, new(20, 20), 0f, Color.WHITE);
    }

    internal override Texture2D GetTexture()
    {
        if (shootingDir == Direction.right) return boostTexture;
        else return leftTexture;
    }

    internal override void ChangeDirection()
    {
        if (shootingDir == Direction.left) shootingDir = Direction.right;
        else shootingDir = Direction.left;
    }
}
