using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : Unit, IPoolable
{
    [SerializeField] private EnemyMovement _movement;
    [SerializeField] private EnemyAttackZone _attackZone;
    [SerializeField] private UnitHelathBar _healthBar;

    private IPool _pool;

    private void OnDisable()
    {
        OnDeath -= Destroy;
    }

    public void Init(float maxHealth, Particle hit, ParticleSystem death, Transform target, float extraDamage)
    {
        new EnemyParticles(this, death, hit);
        Animator animator = GetComponent<Animator>();
        EnemyAnimator enemyAnimator = new EnemyAnimator();

        enemyAnimator.Init(animator);
        _movement.Init(target);
        _attackZone.Init(enemyAnimator, extraDamage);

        OnDeath += Destroy;
        base.Init(maxHealth, _healthBar);
        _healthBar.HealthChanged();
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

    public void HitPlayer()
    {
        _attackZone.HitPlayer();
    }
}