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

    public Lever(int x, int y)
    {
        position = new(x, y);
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
            World.camc.OverrideCamera(2000, new(0, 0));
        }
    }

    public bool IsOn()
    {
        return isFlipped;
    }
}
