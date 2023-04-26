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
        World.CheckEnemyHits();
        World.CheckCollectibleHits();
    }

    private void Controls()
    {
        KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

        p.Controls();

        PowerUpController.Activate(key);
    }

    private void Render()
    {
        InitContext();

        // Draw the parallax background (this will also draw the different layers)
        World.DrawBackground();

        // Player stuff
        p.MoveAndRender();
        camera2D.target = Player.Position + p.CameraMovementLerp();
        camera2D.zoom = p.Zoom;

        PowerUpController.boosts[PowerUps.Projectile].Update();
        PowerUpController.DrawParticles();

        // World and enemies
        World.Render();
        World.ec.DrawEnemies();
        World.cc.DrawCollectibles();


        EndContext();
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
