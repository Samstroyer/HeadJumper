using Raylib_cs;

internal class WorldObject
{
    internal Rectangle R { get; set; }
    internal Color C; // Color.DarkGreen;

    internal WorldObject(Rectangle r)
    {
        R = r;

        // Change division (now 2000) to final map size
        double progress = Raymath.Lerp(0, 255, r.x / 2000);
        C = new((byte)progress, 255 - (byte)progress, 100, 255);
    }

    internal void Render()
    {
        Raylib.DrawRectangleRec(R, C);
    }
}
