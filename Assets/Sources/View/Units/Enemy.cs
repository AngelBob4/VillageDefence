using UnityEngine;

public class Enemy : Unit, IPoolable
{
    private IPool _pool;
    private EnemyParticles _enemyParticles;

    public void Init(float maxHealth, Particle hit, ParticleSystem death)
    {
        _enemyParticles = new EnemyParticles(this, death, hit);
        Death += Destroy;
        base.Init(maxHealth);
    }

    public void SetPool(IPool objectPool)
    {
        _pool = objectPool;
    }

    public void BackToPool()
    {
        gameObject.SetActive(false);
        _pool.Release(this);
    }

    public void Destroy()
    {
        if (_pool != null)
        {
            BackToPool();
            return;
        }

        Destroy(gameObject);
    }
}