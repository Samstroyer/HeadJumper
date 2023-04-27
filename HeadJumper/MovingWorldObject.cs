using System.Numerics;
using System.Timers;
using Raylib_cs;

internal class MovingWorldObject : WorldObject
{
    private Vector2 bounds;
    private float speed;

    private Vector2 startPosition;
    private float progress = 0;

    internal MovingWorldObject(Rectangle r, float speed_, Vector2 bounds_) : base()
    {
        startPosition = new(r.x, r.y);
        speed = speed_;
        bounds = bounds_;

        X = (int)r.x;
        Y = (int)r.y;
        Width = (int)r.width;
        Height = (int)r.height;
    }

    internal override void Render()
    {
        base.Render();
    }

    internal override void Move()
    {
        progress += speed;
        var change = GetLocalPosition();

        X = (int)(startPosition.X + change.X);
        Y = (int)(startPosition.Y + change.Y);
    }

    internal override Vector2 GetLocalPosition()
    {
        float x_ = (float)(Math.Cos(progress) * bounds.X);
        float y_ = (float)(Math.Sin(progress) * bounds.Y);

        return new(x_, y_);
    }

    internal override Vector2 GetSpeedChange()
    {
        Vector2 prev = GetLocalPosition();

        float nextProgress = progress + speed;

        float x_ = (float)(Math.Cos(nextProgress) * bounds.X);
        float y_ = (float)(Math.Sin(nextProgress) * bounds.Y);

        return new Vector2(x_, y_) - prev;
    }
}
