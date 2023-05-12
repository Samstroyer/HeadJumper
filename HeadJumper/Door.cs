using Raylib_cs;

public class Door : Interactable
{
    public int maxWorldDist;

    Rectangle hitbox
    {
        get
        {
            return new(position.X, position.Y, size.X, size.Y);
        }
    }

    public Door(int x, int y) : base(x, y)
    {
        size = new(40, 40);
        maxWorldDist = x;
    }
}
