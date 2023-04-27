using System.Numerics;
using Raylib_cs;
using System.IO;

internal class Engine
{
    public static Vector2 screenDim;
    Camera2D camera2D;

    Player p;

    internal Engine()
    {
        p = new();

        screenDim = new(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        camera2D = new(new(screenDim.X / 2, screenDim.Y / 2), Player.Position, 0f, 1f);

        World.LoadObjects();
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
        PowerUpController.Activate(key);

        p.Controls();
    }

    private void Render()
    {
        InitContext();

        // Player stuff
        p.MoveAndRender();
        camera2D.target = Player.Position + p.CameraMovementLerp();
        camera2D.zoom = p.Zoom;

        // boosts
        PowerUpController.boosts[PowerUps.Projectile].Update();
        PowerUpController.DrawParticles();

        // World and enemies
        World.Render();

        EndContext();
    }

    #region Context init and end
    private void InitContext()
    {
        Raylib.BeginDrawing();

        // Draw the parallax background (this will also draw the different layers)
        // Also has the clearbackground raylib function
        World.DrawBackground();

        Raylib.BeginMode2D(camera2D);
    }

    private void EndContext()
    {
        Raylib.EndMode2D();
        PowerUpController.RenderBoostSymbols();
        Player.DrawHUD();
        Raylib.EndDrawing();
    }
    #endregion 
}
