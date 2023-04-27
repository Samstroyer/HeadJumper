using Raylib_cs;

public class BoulderStack : Interactable
{
    Rectangle hitbox
    {
        get
        {
            return new(position.X, position.Y, size.X, size.Y);
        }
    }

    public BoulderStack(int x, int y) : base(x, y)
    {
        size = new(100, 100);
    }
}
