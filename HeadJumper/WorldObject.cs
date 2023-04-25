using Raylib_cs;

internal abstract class WorldObject
{
    internal Rectangle R;
    internal Color C; // Color.DarkGreen;

    internal WorldObject(Rectangle r)
    {
        R = r;

        // Change division (now 2000) to final map size
        double progress = Raymath.Lerp(0, 255, r.x / 2000);
        C = Raylib.GetImageColor(ImageLib.ColorMap, (int)progress, 0);
    }

    internal virtual void Render()
    {
        Raylib.DrawRectangleRec(R, C);
    }

    internal virtual void Move() { }
}
