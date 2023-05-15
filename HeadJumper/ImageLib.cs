using Raylib_cs;

// This class is for loading item textures only once and not killing VRAM

internal static class ImageLib
{
    internal static Texture2D Coin = Raylib.LoadTexture("Sprites/Coin.png");
    internal static Texture2D Heart = Raylib.LoadTexture("Sprites/Heart.png");
    internal static Texture2D Spikes = Raylib.LoadTexture("Sprites/Spikes.png");
    internal static Texture2D HealthPotion = Raylib.LoadTexture("Sprites/HealthPotion.png");
    internal static Texture2D Background = Raylib.LoadTexture("Assets/Background.png");
    internal static Texture2D DistantBackground = Raylib.LoadTexture("Assets/DistantBackground.png");
    internal static Texture2D HUDElement = Raylib.LoadTexture("Assets/Overlay.png");
    internal static Texture2D SlimeSpriteSheet = Raylib.LoadTexture("Sprites/SlimeSpriteSheet.png");

    internal static Texture2D AlmostFullHealth = Raylib.LoadTexture("Sprites/AlmostFull.png");
    internal static Texture2D MediumHealth = Raylib.LoadTexture("Sprites/MediumHealth.png");
    internal static Texture2D NoHealth = Raylib.LoadTexture("Sprites/NoHealth.png");

    internal static Image SkyFade = Raylib.LoadImage("Assets/SkyFade.png");
    internal static Image ColorMap = Raylib.LoadImage("Assets/ColorMap.png");
}
