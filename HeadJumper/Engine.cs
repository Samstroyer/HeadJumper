using System.Numerics;
using Raylib_cs;

internal class Engine
{
    Vector2 screenDim;
    Camera2D camera2D;

    Player p;

    internal Engine()
    {
        p = new();

        screenDim = new(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        camera2D = new(new(screenDim.X / 2, screenDim.Y / 2), p.Position, 0f, 1f);
    }

    internal void Run()
    {
        Controls();

        Logic();

        Render();
    }

    private void Logic()
    {
        // This order gives you a "pushing" effect when moving. 
        // I think it makes it more immersive
        camera2D.target = p.Position + p.CameraMovementLerp();
        camera2D.zoom = p.Zoom;

        p.Move();

        World.CheckEnemyHits(new(p.Position.X, p.Position.Y, p.Size.X, p.Size.Y));
    }

    private void Controls()
    {
        KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) p.Jump();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) p.movement = Dir.Left;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) p.movement = Dir.Right;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_Z)) p.Zooming(true);
        else p.Zooming(false);

        PowerUpController.Activate(key);
    }

    private void Render()
    {
        InitContext();

        // Player stuff
        p.Draw();

        // World and enemies
        World.Render();
        World.ec.DrawEnemies();

        EndContext();
    }

    private void RenderCharacter()
    {
        Raylib.DrawRectangle((int)p.Position.X, (int)p.Position.Y, (int)p.Size.X, (int)p.Size.Y, p.C);
    }

    #region Context init and end
    private void InitContext()
    {
        Raylib.BeginDrawing();
        Raylib.BeginMode2D(camera2D);
        Raylib.ClearBackground(Color.WHITE);
    }

    private void EndContext()
    {
        Raylib.EndMode2D();
        PowerUpController.RenderBoostSymbols();
        Raylib.EndDrawing();
    }
    #endregion 
}
