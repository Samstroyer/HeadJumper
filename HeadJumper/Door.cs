using System;

public class Door : Interactable
{
    public Door(int x, int y) : base(x, y)
    {
        size = new(40, 40);
    }
}
