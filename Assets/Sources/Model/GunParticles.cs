using UnityEngine;

public class GunParticles : Object
{
    private ParticlePool _particlePool;
    private Gun _gun;
    private Transform _particlePosition;
    private TrailRenderer _trail;

    private Vector3 _enemyOffset = new Vector3(0, 1.5f, 0);

    public GunParticles(Particle particle, Gun gun, Transform particlePosition, TrailRenderer trail)
    {
        _particlePool = new ParticlePool(particle);
        _gun = gun;
        _particlePosition = particlePosition;
        _trail = Object.Instantiate(trail);
        _trail.gameObject.SetActive(false);

        _gun.Shot += ShootParticles;
    }

    private void ShootParticles(Enemy enemy)
    {
        Particle particle = _particlePool.GetObject();
        particle.gameObject.SetActive(true);
        particle.gameObject.transform.SetParent(_particlePosition);
        particle.gameObject.transform.localPosition = Vector3.zero;
        particle.Play();

        Vector3[] trailPositions = new Vector3[] { _particlePosition.position, enemy.Position + _enemyOffset};
        _trail.transform.position = _particlePosition.position;
        _trail.Clear();
        _trail.AddPositions(trailPositions);
        _trail.gameObject.SetActive(true);
    }
}