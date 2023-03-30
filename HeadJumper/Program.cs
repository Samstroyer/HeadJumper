using Raylib_cs;

Engine e;

Setup();
Draw();

void Setup()
{
    Raylib.InitWindow(1000, 800, "Head Jumper");
    Raylib.SetTargetFPS(60);
    e = new();
}

void Draw()
{
    e.Run();
}