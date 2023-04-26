using System.Text.Json.Serialization;
using Raylib_cs;

internal class StaticWorldObject : WorldObject
{
    internal int x;
    internal int y;
    internal int width;
    internal int height;

    internal StaticWorldObject(Rectangle r) : base(r) { }

    internal void Load()
    {
        R = new(x, y, width, height);
    }

    internal override void Render()
    {
        base.Render();
    }
}
