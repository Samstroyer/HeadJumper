using Raylib_cs;

public class Door : Interactable
{
    public static Texture2D texture = Raylib.LoadTexture("./Sprites/DoorSprite.png");

    public Door(int x, int y) : base(x, y) { }

    public override bool Border()
    {
        if (Raylib.CheckCollisionPointLine(Player.Position, new(position.X, -10000), new(position.X, 10000), 40)) return true;
        else return false;
    }
}
