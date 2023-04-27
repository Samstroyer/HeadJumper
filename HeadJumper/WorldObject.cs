using System.Text.Json.Serialization;
using System.Numerics;
using Raylib_cs;

internal class WorldObject
{
    [JsonIgnore]
    public Rectangle r
    {
        get
        {
            return new(X, Y, Width, Height);
        }
    }

    [JsonPropertyName("X"), JsonInclude]
    public int X { get; set; }

    [JsonPropertyName("Y"), JsonInclude]
    public int Y { get; set; }

    [JsonPropertyName("Width"), JsonInclude]
    public int Width { get; set; }

    [JsonPropertyName("Height"), JsonInclude]
    public int Height { get; set; }

    [JsonIgnore]
    internal Color C;

    internal WorldObject() { }

    internal WorldObject(Rectangle r)
    {
        X = (int)r.x;
        Y = (int)r.y;
        Width = (int)r.width;
        Height = (int)r.height;

        // Change division (now 2000) to final map size
        double progress = Raymath.Lerp(0, 255, r.x / World.Border.X);
        C = Raylib.GetImageColor(ImageLib.ColorMap, (int)progress, 0);
    }

    internal virtual void Render()
    {
        Raylib.DrawRectangleRec(r, C);
    }

    internal virtual void Move() { }

    internal virtual Vector2 GetLocalPosition() { return new(0, 0); }
    internal virtual Vector2 GetSpeedChange() { return new(0, 0); }

    internal void LoadColor()
    {
        double progress = Raymath.Lerp(0, 255, r.x / World.Border.X);
        C = Raylib.GetImageColor(ImageLib.ColorMap, (int)progress, 0);
    }
}
