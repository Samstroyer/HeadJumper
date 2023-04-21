using System.Numerics;
using Raylib_cs;

static internal class PowerUpController
{
    internal static List<BoostInfo> boosts = new()
    {
        new("Speed Boost", "Gives the player speed for a set amount of time", 10000, 5000) {boostTexture = Raylib.LoadTexture("sprites/JumpBoost.png")},
        // new("Speed Boost", "Gives the player speed for a set amount of time", 10000, 5000) {boostTexture = Raylib.LoadTexture("sprites/JumpBoost.png")},
        // new("Speed Boost", "Gives the player speed for a set amount of time", 10000, 5000) {boostTexture = Raylib.LoadTexture("sprites/JumpBoost.png")},
    };

    internal static void RenderBoostSymbols()
    {
        int xPos = 0;

        foreach (var b in boosts)
        {
            Raylib.DrawTexture(b.boostTexture, xPos + 10, 10, Color.WHITE);
            xPos += 50;
        }
    }
}
