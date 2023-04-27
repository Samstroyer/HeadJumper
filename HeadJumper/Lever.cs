using System.Numerics;
using Raylib_cs;

public class Lever
{
    bool isFlipped = false;
    static Vector2 size = new(40, 40);
    Vector2 position;

    public Lever(int x, int y)
    {
        position = new(x, y);
    }

    public void Draw()
    {
        Color c = isFlipped ? Color.RED : Color.GREEN;
        Raylib.DrawRectangleRec(new(position.X, position.Y, size.X, size.Y), c);
    }
}
