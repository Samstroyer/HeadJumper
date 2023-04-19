using System;

internal class BoostInfo
{
    internal string Name { get; set; }
    internal string Info { get; set; }

    internal System.Timers.Timer cooldownTimer;
    internal System.Timers.Timer onTimer;

    internal bool isActive = false;
    internal bool available = true;

    internal BoostInfo(string name, string info, float cooldown, float timeActive)
    {
        Name = name; Info = info; cooldownTimer = new(cooldown); onTimer = new(timeActive);
    }
}
