using System.Numerics;
using System.Timers;
using Raylib_cs;

public class CameraController
{
    public Camera2D cam;
    public bool targetOverride = false;
    private Vector2 overridenPosition;

    private System.Timers.Timer playerFocus;

    public CameraController(Vector2 offset, Vector2 target, float rotation, float zoom)
    {
        cam = new(offset, target, rotation, zoom);
        playerFocus = new()
        {
            AutoReset = false,
            Enabled = true
        };
        playerFocus.Elapsed += TurnOffFocus;
    }

    private void TurnOffFocus(Object source, ElapsedEventArgs e)
    {
        targetOverride = false;
        overridenPosition = new(0, 0);
    }

    public void OverrideCamera(int msTime, Vector2 position)
    {
        targetOverride = true;
        overridenPosition = position;
        playerFocus.Interval = msTime;
        playerFocus.Start();
    }

    public void FocusCamera(Vector2 basePos)
    {
        if (targetOverride)
        {
            cam.target = new(
                Raymath.Lerp(cam.target.X, overridenPosition.X, 0.15f),
                Raymath.Lerp(cam.target.Y, overridenPosition.Y, 0.15f)
                );
        }
        else
        {
            cam.target = new(
                Raymath.Lerp(cam.target.X, basePos.X, 0.15f),
                Raymath.Lerp(cam.target.Y, basePos.Y, 0.15f)
                );
        }
    }
}
