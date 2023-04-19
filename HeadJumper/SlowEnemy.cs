using System;

internal class SlowEnemy : Enemy
{
    internal SlowEnemy()
    {
        Damage = 20;
        Hitpoints = 200;
        Speed = 2;
    }
}
