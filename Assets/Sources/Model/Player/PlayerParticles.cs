using UnityEngine;

public class PlayerParticles : Object
{
    private Player _player;
    private ParticlePool _hitPool;
    private AudioSource _hitAudio;
    private Vector3 _particleOffset = new Vector3(0, 1.5f, 0);

    public PlayerParticles(Player player, Particle hitParticle, AudioSource audioHit)
    {
        _hitAudio = audioHit;
        _player = player;
        _hitPool = new ParticlePool(hitParticle);

        _player.OnGetDamage += GetHit;
    }

    public void GetHit()
    {
        Particle particle = _hitPool.GetObject();
        particle.gameObject.SetActive(true);
        particle.gameObject.transform.SetParent(_player.gameObject.transform);
        particle.gameObject.transform.localPosition = Vector3.zero + _particleOffset;
        particle.Play();

        _hitAudio.Play();
    }
}
