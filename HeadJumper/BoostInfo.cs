using System;

public class BoostInfo
{
    public string Name { get; set; }
    public string Info { get; set; }

    public System.Timers.Timer cooldownTimer;
    public System.Timers.Timer onTimer;

    public bool isActive = false;
    public bool available = true;

    public BoostInfo(string name, string info, float cooldown, float timeActive)
    {
        Name = name; Info = info; cooldownTimer = new(cooldown); onTimer = new(timeActive);
    }
}
