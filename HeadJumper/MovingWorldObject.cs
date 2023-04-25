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
        var change = GetSpeed();

        R.x = startPosition.X + change.X;
        R.y = startPosition.Y + change.Y;
        // R.x = startPosition.X + (float)(Math.Cos(progress) * bounds.X);
        // R.y = startPosition.Y + (float)(Math.Sin(progress) * bounds.Y);
    }

    internal override Vector2 GetSpeed()
    {
        float x_ = (float)(Math.Cos(progress) * bounds.X);
        float y_ = (float)(Math.Sin(progress) * bounds.Y);

        return new(x_, y_);
    }
}
