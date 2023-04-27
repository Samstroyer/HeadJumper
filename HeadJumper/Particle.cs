using System.Numerics;
using Raylib_cs;

internal class Particle
{
    private static Random r = new();
    static Vector2 bounds = new(20, 20);
    internal Vector2 position;

    internal Particle()
    {
        position = new(r.Next((int)-bounds.X, (int)bounds.X), r.Next(0, (int)bounds.Y));
    }

    internal void UpdateAndRender(Color c)
    {
        int xPos = (int)position.X + (int)Player.Position.X + (int)bounds.X;
        int yPos = (int)position.Y + (int)Player.Position.Y + (int)bounds.Y;
        Raylib.DrawRectangle(xPos, yPos, 4, 4, c);

        position += new Vector2(r.Next(-1, 2), -r.Next(1, 2));
        if (position.X > bounds.X
            || position.X < -bounds.X
            || position.Y < -bounds.Y) Respawn();
    }

    private void Respawn()
    {
        position = new(r.Next((int)-bounds.X, (int)bounds.X), bounds.Y);
    }
}
