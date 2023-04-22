using Raylib_cs;

internal class StationaryEnemy : Enemy
{

    internal StationaryEnemy()
    {
        Damage = 20;
        Hitpoints = 200;
        Size = new(10, 10);
    }

    internal override void UpdateAndDraw()
    {
        base.UpdateAndDraw();
    }
}
