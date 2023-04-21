using System.Numerics;
using Raylib_cs;

// Set direction and spawn from Player.Position when activated!

internal class Projectile : BoostInfo
{
    internal int speed = 1;
    internal Vector2 position;

    internal enum Direction
    {
        left = -1,
        right = 1
    }

    internal Projectile(string name, string info, float cooldown, float timeActive, KeyboardKey activationKey) : base(name, info, cooldown, timeActive, activationKey)
    {

    }


}
