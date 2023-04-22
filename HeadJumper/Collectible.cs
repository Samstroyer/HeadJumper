using System.Numerics;
using Raylib_cs;

internal abstract class Collectible : Item
{
    internal Vector2 position;
    internal Rectangle size;

    internal virtual void Render()
    {
        Raylib.DrawRectangleRec(new(position.X, position.Y, 10, 10), Color.BLACK);
        // Raylib.DrawTexturePro(texture, new(0, 0, texture.width, texture.height), new(position.X, position.Y, size.x, size.y), new(0, 0), 0f, Color.WHITE);
    }
}
