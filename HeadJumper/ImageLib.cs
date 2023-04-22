using Raylib_cs;

// This class is for loading item textures only once and not killing VRAM

internal static class ImageLib
{
    static Texture2D Coin = Raylib.LoadTexture("Sprites/Coin.png");
}
