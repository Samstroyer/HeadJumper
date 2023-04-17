using System.Numerics;
using Raylib_cs;

public class Engine
{
    Vector2 screenDim;
    Camera2D camera2D;
    World world;

    Level levelController = new();

    Player p;
    EnemyController ec;

    public Engine()
    {
        world = new();
        ec = new();
        p = new();
        screenDim = new(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        camera2D = new(new(screenDim.X / 2, screenDim.Y / 2), p.Position, 0f, 1f);
    }

    public void Run()
    {
        Controls();

        Logic();

        Render();
    }

    private void Logic()
    {
        camera2D.target = p.Position;
    }

    private void Controls()
    {
        KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) p.Jump();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) p.Move(Dir.Left);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) p.Move(Dir.Right);
    }

    private void Render()
    {
        InitContext();

        p.Draw();

        EndContext();
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
        Raylib.BeginMode2D(camera2D);
        Raylib.ClearBackground(Color.WHITE);
    }

    private void EndContext()
    {
        Raylib.EndMode2D();
        Raylib.EndDrawing();
    }
}
