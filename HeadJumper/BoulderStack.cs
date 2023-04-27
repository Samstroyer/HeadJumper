using System;

public class BoulderStack : Interactable
{
    public BoulderStack(int x, int y) : base(x, y)
    {
        size = new(100, 100);
    }
}
