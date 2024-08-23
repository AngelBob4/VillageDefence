using UnityEngine;

public class GunParticles
{
    private ParticlePool _particlePool;
    private Gun _gun;
    private Transform _particlePosition;

    public GunParticles(Particle particle, Gun gun, Transform particlePosition)
    {
        _particlePool = new ParticlePool(particle);
        _gun = gun;
        _particlePosition = particlePosition;

        _gun.Shot += ShootParticles;
    }

    private void ShootParticles()
    {
        Particle particle = _particlePool.GetObject();
        particle.gameObject.SetActive(true);
        particle.gameObject.transform.SetParent(_particlePosition);
        particle.gameObject.transform.localPosition = Vector3.zero;
        particle.Play();
    }
}