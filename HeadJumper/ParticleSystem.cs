using Raylib_cs;

internal class ParticleSystem
{
    List<Particle> particles;
    Color particleColor;

    internal ParticleSystem(Color c)
    {
        particleColor = c;

        // Create new system with 10 particles
        particles = new();
        for (int i = 0; i < 5; i++)
        {
            particles.Add(new());
        }
    }

    internal void RenderParticles()
    {
        foreach (Particle p in particles)
        {
            p.UpdateAndRender(particleColor);
        }
    }
}
