using System.Numerics;
using Raylib_cs;

public abstract class Interactable
{
    public bool obstructing = true;
    protected Vector2 size = new(60, 60);
    public int maxWorldDist;
    public Vector2 position;

    public Interactable(int x, int y)
    {
        position = new(x - 20, y - 20);
        maxWorldDist = x;
    }

    public virtual void DrawAndUpdate(bool counterPartOn)
    {
        obstructing = !counterPartOn;
        Color c = obstructing ? Color.RED : Color.GREEN;
        Raylib.DrawRectangleRec(new(position.X, position.Y, size.X, size.Y), c);
    }

    public virtual bool Border()
    {
        return false;
    }
}
