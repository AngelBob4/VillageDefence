using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Particle : MonoBehaviour, IPoolable
{
    private IPool _objectPool;
    private ParticleSystem _particleSystem;

    private void OnDisable()
    {
        if (_objectPool != null)
        {
            BackToPool();
            return;
        }

        Destroy(gameObject);
    }

    public void Play()
    {
        if (_particleSystem == null)
            _particleSystem = GetComponent<ParticleSystem>();

        _particleSystem.Play();
    }

    public void SetPool(IPool objectPool)
    {
        _objectPool = objectPool;
    }

    public void BackToPool()
    {
        gameObject.SetActive(false);
        _objectPool.Release(this);
    }
}