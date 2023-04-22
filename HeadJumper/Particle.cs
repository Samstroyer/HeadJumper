using System.Numerics;
using Raylib_cs;

internal class Particle
{
    private static Random r = new();
    static Vector2 bounds = new(20, 20);
    internal Vector2 position;
    private Vector2 speed;

    internal Particle()
    {
        position = new(r.Next((int)-bounds.X, (int)bounds.X), r.Next(0, (int)bounds.Y));
        speed = new((float)r.Next(50, 150) / 100, (float)-r.Next(50, 150) / 100);
    }

    internal void UpdateAndRender(Color c)
    {
        Raylib.DrawRectangle((int)position.X + (int)Player.Position.X + (int)bounds.X, (int)position.Y + (int)Player.Position.Y + (int)bounds.Y, 2, 2, c);

        position += speed;
        if (position.X > bounds.X) position.X = (int)-bounds.X;
        if (position.Y < -bounds.Y) position.Y = bounds.Y;
    }
}
