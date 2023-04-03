using Raylib_cs;

public class Platform
{
    public Rectangle R { get; set; }
    public Color C { get; set; } = Color.DARKGREEN;

    public Platform()
    {
        R = new Rectangle(-100, 20, 200, 10);
    }

    public void Render()
    {
        Raylib.DrawRectangleRec(R, C);
    }
}
