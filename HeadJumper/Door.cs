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

    public override void DrawAndUpdate(bool counterPartOn)
    {
        obstructing = !counterPartOn;
        Color c = obstructing ? Color.RED : Color.GREEN;
        if (obstructing)
        {
            Raylib.DrawTexturePro(texture, new(0, 0, 40, 40), new(position.X, position.Y, size.X, size.Y), new(0, 0), 0f, Color.WHITE);
        }
        else
        {
            Raylib.DrawTexturePro(texture, new(40, 40, 40, 40), new(position.X, position.Y, size.X, size.Y), new(0, 0), 0f, Color.WHITE);
        }
    }
}
