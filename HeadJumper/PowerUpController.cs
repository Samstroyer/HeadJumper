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
    internal static Dictionary<PowerUps, BoostInfo> boosts = new()
    {
        { PowerUps.Speed, new("Speed Boost", "Gives the player speed for a set amount of time", 10000, 5000, KeyboardKey.KEY_ONE) {boostTexture = Raylib.LoadTexture("sprites/JumpBoost.png")} }

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
        int spacing = 50;
        int xPos = 10;
        int counter = 1;

        foreach (var b in boosts)
        {
            Raylib.DrawTexture(b.Value.boostTexture, xPos, 10, Color.WHITE);

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
