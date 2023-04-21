using System.Timers;
using Raylib_cs;

internal class BoostInfo
{
    internal string Name { get; set; }
    internal string Info { get; set; }

    internal System.Timers.Timer cooldownTimer;
    internal System.Timers.Timer activeTimer;

    internal bool isActive = false;
    internal bool available = true;

    internal Texture2D boostTexture;

    internal KeyboardKey trigger;

    internal BoostInfo(string name, string info, float cooldown, float timeActive, KeyboardKey activationKey)
    {
        Name = name; Info = info; cooldownTimer = new(cooldown); activeTimer = new(timeActive); trigger = activationKey;

        cooldownTimer.Elapsed += CooldownEvent;
        activeTimer.Elapsed += ActiveEvent;
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
        

        cooldownTimer.Start();
    }

    private void ActiveEvent(Object source, ElapsedEventArgs e)
    {

    }

    private void CooldownEvent(Object source, ElapsedEventArgs e)
    {

    }
}
