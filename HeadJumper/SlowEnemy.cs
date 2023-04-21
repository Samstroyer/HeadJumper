using Raylib_cs;

internal class SlowEnemy : Enemy
{

    internal SlowEnemy()
    {
        Damage = 20;
        Hitpoints = 200;
        Speed = 2;
        Size = new(10, 10);


    }

    internal override void UpdateAndDraw()
    {
        UpdateHitbox();
        base.UpdateAndDraw();

        // Render the hitbox - for debug
        Raylib.DrawRectangleRec(hitbox, Color.BLUE);
    }

    private void UpdateHitbox()
    {
        float x = Position.X + (Size.X / 2) - 2;
        float y = Position.Y - 3;
        float width = 4;
        float height = 6;
        hitbox = new(x, y, width, height);
    }
}
