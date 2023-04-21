using Raylib_cs;

internal class WorldObject
{
    internal Rectangle R { get; set; }
    internal Color C { get; set; } = Color.DARKGREEN;

    internal WorldObject(Rectangle r)
    {
        R = r;
    }

    internal void Render()
    {
        Raylib.DrawRectangleRec(R, C);
    }
}
