using Raylib_cs;

// This class is for loading item textures only once and not killing VRAM

internal static class ImageLib
{
    internal static Texture2D Coin = Raylib.LoadTexture("Sprites/Coin.png");
    internal static Texture2D Heart = Raylib.LoadTexture("Sprites/Heart.png");
    internal static Texture2D Spikes = Raylib.LoadTexture("Sprites/Spikes.png");
    internal static Texture2D HealthPotion = Raylib.LoadTexture("Sprites/HealthPotion.png");
    internal static Texture2D Background = Raylib.LoadTexture("Sprites/Background.png");
    internal static Image ColorMap = Raylib.LoadImage("Assets/ColorMap.png");
}
