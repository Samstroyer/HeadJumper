using System.Numerics;
using Raylib_cs;

internal enum PowerUps
{
    Speed,
    Jump,
    Projectile,
}

static internal class PowerUpController
{
    static Color TransparentGray = new(100, 100, 100, 100);

    internal static Dictionary<PowerUps, BoostInfo> boosts = new()
    {
        { PowerUps.Speed, new("Speed Boost", "Gives the player speed for a set amount of time", 10000, 5000, KeyboardKey.KEY_ONE) {boostTexture = Raylib.LoadTexture("sprites/SpeedBoost.png")} },
        { PowerUps.Jump, new("Jump Boost", "Gives the player jump boost for a set amount of time", 5000, 5000, KeyboardKey.KEY_TWO) {boostTexture = Raylib.LoadTexture("sprites/JumpBoost.png")} },
        { PowerUps.Projectile, new Projectile("Projectile", "Shoots a projectile that kills all enemies in its path. Travels only for 3 seconds", 15000, 3000, KeyboardKey.KEY_THREE) {boostTexture = Raylib.LoadTexture("sprites/Projectile.png")} },

    };

    internal static void Activate(KeyboardKey key)
    {
        foreach (var b in boosts)
        {
            if (b.Value.trigger == key) b.Value.TryActivate();
        }
    }

    internal static void RenderBoostSymbols()
    {
        int spacing = 70;
        int xPos = 10;
        int counter = 1;

        foreach (var b in boosts)
        {
            Raylib.DrawRectangle(xPos, 10, 40, 40, TransparentGray);
            Texture2D boostTexture = b.Value.GetTexture();
            Raylib.DrawTexture(boostTexture, xPos, 10, Color.WHITE);

            if (b.Value.available)
            {
                int textWidth = Raylib.MeasureText("key: " + counter.ToString(), 16);
                Raylib.DrawText("key: " + counter.ToString(), (xPos + 20) - (textWidth / 2), 55, 16, Color.GREEN);
            }
            else if (b.Value.isActive)
            {
                var time = b.Value.lastEventTime - DateTime.Now;
                string displayedTime = (time.Seconds + "." + (Math.Floor((decimal)time.Milliseconds / 100))).ToString();

                int textWidth = Raylib.MeasureText(displayedTime, 16);
                Raylib.DrawText(displayedTime, (xPos + 20) - (textWidth / 2), 55, 16, Color.BLUE);
            }
            else
            {
                var time = b.Value.lastEventTime - DateTime.Now;
                string displayedTime = (time.Seconds + "." + (Math.Floor((decimal)time.Milliseconds / 100))).ToString();

                int textWidth = Raylib.MeasureText(displayedTime, 16);
                Raylib.DrawText(displayedTime, (xPos + 20) - (textWidth / 2), 55, 16, Color.RED);
            }

            xPos += spacing; counter++;
        }
    }
}
