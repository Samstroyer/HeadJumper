using Raylib_cs;

internal class ParticleSystem
{
    List<Particle> particles;
    Color particleColor;

    internal ParticleSystem(Color c)
    {
        particleColor = c;

        particles = new();

        for (int i = 0; i < 10; i++)
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
