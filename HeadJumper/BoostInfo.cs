using System.Timers;
using Raylib_cs;

internal class BoostInfo
{
    internal string Name { get; set; }
    internal string Info { get; set; }

    internal DateTime lastEventTime;

    internal System.Timers.Timer cooldownTimer;
    internal System.Timers.Timer activeTimer;

    internal bool isActive = false;
    internal bool available = true;

    internal Texture2D boostTexture;

    internal KeyboardKey trigger;

    internal BoostInfo(string name, string info, float cooldown, float timeActive, KeyboardKey activationKey)
    {
        Name = name; Info = info; cooldownTimer = new(cooldown); activeTimer = new(timeActive); trigger = activationKey;

        activeTimer.AutoReset = false;
        cooldownTimer.AutoReset = false;

        cooldownTimer.Elapsed += CooldownEnd;
        activeTimer.Elapsed += ActiveEnd;

    }

    internal void TryActivate()
    {
        if (!available) return;
        if (isActive) return;

        Activate();
    }

    private void Activate()
    {
        isActive = true; available = false;
        activeTimer.Start();
        lastEventTime = DateTime.Now.AddSeconds(activeTimer.Interval / 1000);
    }

    private void ActiveEnd(Object source, ElapsedEventArgs e)
    {
        cooldownTimer.Start();
        isActive = false;
        lastEventTime = DateTime.Now.AddSeconds(cooldownTimer.Interval / 1000);
    }

    private void CooldownEnd(Object source, ElapsedEventArgs e)
    {
        available = true;
    }
}
