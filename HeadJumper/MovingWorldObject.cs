using System.Numerics;
using System.Timers;
using Raylib_cs;

internal class MovingWorldObject : WorldObject
{
    private Vector2 bounds;
    private float speed;

    private Vector2 startPosition;
    private float progress = 0;

    internal MovingWorldObject(Rectangle r, float speed_, Vector2 bounds_) : base(r)
    {
        startPosition = new(r.x, r.y);
        speed = speed_;
        bounds = bounds_;
    }

    internal override void Render()
    {
        base.Render();
    }

    internal override void Move()
    {
        progress += speed;
        R.x = startPosition.X + (float)(Math.Cos(progress) * bounds.X);
    }
}
