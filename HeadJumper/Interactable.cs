using System.Numerics;
using Raylib_cs;

public abstract class Interactable
{
    protected bool obstructing = true;
    protected Vector2 size;
    public Vector2 position;

    public Interactable(int x, int y)
    {
        position = new(x, y);
    }

    public virtual void DrawAndUpdate(bool counterPartOn)
    {
        obstructing = !counterPartOn;
        Color c = obstructing ? Color.RED : Color.GREEN;
        Raylib.DrawRectangleRec(new(position.X, position.Y, size.X, size.Y), c);
    }

    
}
