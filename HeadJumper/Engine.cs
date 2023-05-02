using System.Numerics;
using Raylib_cs;
using System.IO;

internal class Engine
{
    public static Vector2 screenDim;

    Player p;

    internal Engine()
    {
        p = new();

        screenDim = new(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

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

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_L)) Console.WriteLine(Player.Position);

        p.Controls();
    }

    private void Render()
    {
        InitContext();

        // Player stuff
        p.MoveAndRender();
        World.SetCamera(p);

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

        Raylib.BeginMode2D(World.camc.cam);
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
