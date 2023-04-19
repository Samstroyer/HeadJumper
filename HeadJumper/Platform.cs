using Raylib_cs;

internal class WorldObjects
{
    internal Rectangle R { get; set; }
    internal Color C { get; set; } = Color.DARKGREEN;

    internal WorldObjects()
    {
        R = new Rectangle(-100, 20, 200, 10);
    }

    internal void Render()
    {
        Raylib.DrawRectangleRec(R, C);
    }
}
