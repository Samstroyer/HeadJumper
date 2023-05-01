using System.Numerics;
using System.Timers;
using Raylib_cs;

public class CameraController
{
    public Camera2D cam;
    private bool targetOverride = false;
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
    }

    private void TurnOffFocus(Object source, ElapsedEventArgs e)
    {
        targetOverride = false;
    }

    public void OverrideCamera(int msTime, Vector2 position)
    {
        targetOverride = true;
        overridenPosition = position;
        playerFocus.Interval = msTime;
        playerFocus.Start();
    }

    public void CameraSpecialFocus()
    {
        if (!targetOverride) return;
        Vector2 lerp = new(Raymath.Lerp(cam.target.X, overridenPosition.X, 0.1f), Raymath.Lerp(cam.target.Y, overridenPosition.X, 0.1f));
        cam.target += lerp;
    }
}
