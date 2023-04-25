using Raylib_cs;

internal class StaticWorldObject : WorldObject
{
    internal StaticWorldObject(Rectangle r) : base(r) { }

    internal override void Render()
    {
        base.Render();
    }
}
