using System.Numerics;
using Raylib_cs;

public class Engine
{
    Vector2 screenDim;
    Camera2D camera2D;
    World world;

    Player p;
    EnemyController ec;

    public Engine()
    {
        world = new();
        ec = new();
        p = new();
        screenDim = new(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        camera2D = new(new(screenDim.X / 2, screenDim.Y / 2), p.Position, 0f, p.Zoom);
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            camera2D.target = p.Position;

            InitContext();

            DrawWorld();

            RenderCharacter();

            ec.DrawEnemies();

            EndContext();


            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

            KeyBinds();
        }
    }

    private void KeyBinds()
    {
        KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

        if (key == KeyboardKey.KEY_W) p.Jump();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) p.Position = new Vector2(2, 0) + p.Position;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) p.Position = new Vector2(2, 0) + p.Position;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) p.Position = new Vector2(2, 0) + p.Position;

    }

    private void DrawWorld()
    {
        world.Render();
    }

    private void RenderCharacter()
    {
        Raylib.DrawRectangle((int)p.Position.X, (int)p.Position.Y, (int)p.Size.X, (int)p.Size.Y, p.C);
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
