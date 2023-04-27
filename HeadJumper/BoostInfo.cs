using System.Timers;
using Raylib_cs;

internal class BoostInfo
{
    internal ParticleSystem ps;

    internal string Name { get; set; }
    internal string Info { get; set; }

    internal DateTime lastActivated;

    internal System.Timers.Timer cooldownTimer;
    internal System.Timers.Timer activeTimer;

    internal bool isActive = false;
    internal bool available = true;

    internal Texture2D boostTexture;

    internal KeyboardKey trigger;

    internal BoostInfo(string name, string info, float cooldown, float timeActive, KeyboardKey activationKey, Color particleColor)
    {
        Name = name; Info = info; cooldownTimer = new(cooldown); activeTimer = new(timeActive); trigger = activationKey;
        ps = new(particleColor);

        activeTimer.AutoReset = false;
        cooldownTimer.AutoReset = false;

        cooldownTimer.Elapsed += CooldownEnd;
        activeTimer.Elapsed += ActiveEnd;
    }

    internal virtual void TryActivate()
    {
        if (!available) return;
        if (isActive) return;

        Activate();
    }

    private void Activate()
    {
        isActive = true; available = false;
        activeTimer.Start();
        lastActivated = DateTime.Now.AddSeconds(activeTimer.Interval / 1000);
    }

    private void ActiveEnd(Object source, ElapsedEventArgs e)
    {
        cooldownTimer.Start();
        isActive = false;
        lastActivated = DateTime.Now.AddSeconds(cooldownTimer.Interval / 1000);
    }

    private void CooldownEnd(Object source, ElapsedEventArgs e)
    {
        available = true;
    }

    internal virtual void Update() { }

    internal virtual Texture2D GetTexture()
    {
        return boostTexture;
    }

    internal virtual void ChangeDirection() { }
}
