using System.Numerics;
using Raylib_cs;

internal abstract class Collectible : Item
{
    internal Vector2 position;
    internal Vector2 size;

    internal Rectangle hitbox;

    protected void Render(Texture2D texture)
    {
        Raylib.DrawTexturePro(texture, new(0, 0, texture.width, texture.height), hitbox, new(0, 0), 0f, Color.WHITE);
    }

    internal bool Colliding()
    {
        return Raylib.CheckCollisionRecs(Player.Hitbox, hitbox);
    }
}
