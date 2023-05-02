using System.Numerics;
using Raylib_cs;

public class Lever
{
    Rectangle hitbox
    {
        get
        {
            return new(position.X, position.Y, size.X, size.Y);
        }
    }

    bool isFlipped = false;
    static Vector2 size = new(40, 40);
    Vector2 position;

    Interactable target;

    public Lever(int x, int y)
    {
        position = new(x, y);
    }

    public void AddTarget(Interactable t)
    {
        target = t;
    }

    public void DrawAndCheck()
    {
        Check();

        Color c = isFlipped ? Color.RED : Color.GREEN;
        Raylib.DrawRectangleRec(new(position.X, position.Y, size.X, size.Y), c);
    }

    private void Check()
    {
        // Will need to be changed if i want to be able and switch back, probably not
        if (isFlipped) return;

        if (Raylib.CheckCollisionRecs(Player.Hitbox, hitbox))
        {
            isFlipped = true;
            World.camc.OverrideCamera(2000, target.position);
        }
    }

    public bool IsOn()
    {
        return isFlipped;
    }
}
