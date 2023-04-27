using System.Text.Json.Serialization;
using Raylib_cs;

internal class StaticWorldObject : WorldObject
{
    internal StaticWorldObject() : base() { }

    [JsonConstructor]
    public StaticWorldObject(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    internal override void Render()
    {
        base.Render();
    }
}
