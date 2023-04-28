using System.Numerics;
using Raylib_cs;

public class CameraController
{
    public Camera2D cam;

    public CameraController(Vector2 offset, Vector2 target, float rotation, float zoom)
    {
        cam = new(offset, target, rotation, zoom);
    }
}
