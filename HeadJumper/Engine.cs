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
        camera2D = new(new(screenDim.X / 2, screenDim.Y / 2), Player.Position, 0f, 1f);
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
        camera2D.target = Player.Position + p.CameraMovementLerp();
        camera2D.zoom = p.Zoom;

        World.CheckEnemyHits();
        World.CheckCollectibleHits();
    }

    private void Controls()
    {
        KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_W) || Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) p.Jump();

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) p.movement = Dir.Left;
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) p.movement = Dir.Right;
        else p.movement = Dir.None;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_Z)) p.Zooming(true);
        else p.Zooming(false);

        PowerUpController.Activate(key);

        if (key == KeyboardKey.KEY_UP || key == KeyboardKey.KEY_DOWN) PowerUpController.boosts[PowerUps.Projectile].ChangeDirection();
    }

    private void Render()
    {
        InitContext();

        // Player stuff
        p.MoveAndRender();
        PowerUpController.boosts[PowerUps.Projectile].Update();

        // World and enemies
        World.Render();
        World.ec.DrawEnemies();
        World.cc.DrawCollectibles();


        EndContext();
    }

    private void RenderCharacter()
    {
        Raylib.DrawRectangle((int)Player.Position.X, (int)Player.Position.Y, (int)p.Size.X, (int)p.Size.Y, p.C);
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
        Player.DrawStats();
        Raylib.EndDrawing();
    }
    #endregion 
}
