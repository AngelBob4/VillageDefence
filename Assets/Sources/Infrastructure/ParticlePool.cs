namespace Infrastructure
{
    public class ParticlePool : ObjectPool<Particle>
    {
        public ParticlePool(Particle template) : base(template)
        {
        }
    }
}