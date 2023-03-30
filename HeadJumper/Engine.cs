using System.Numerics;
using Raylib_cs;

public class Engine
{
    Vector2 screenDim;
    Camera2D camera2D;

    Player p;

    public Engine()
    {
        p = new();
        screenDim = new(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        camera2D = new(new(0, 0), p.Position, 0f, 1f);
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            InitContext();

            Raylib.DrawRectangle(0, 0, 10, 10, Color.RED);

            Raylib.DrawRectangle((int)p.Position.X, (int)p.Position.Y, 5, 5, Color.GREEN);

            EndContext();


            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

            if (key == KeyboardKey.KEY_S) p.Position = new Vector2(2, 2) + p.Position;
        }
    }

    private void InitContext()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.BeginMode2D(camera2D);
    }

    private void EndContext()
    {
        Raylib.EndMode2D();
        Raylib.EndDrawing();
    }
}
