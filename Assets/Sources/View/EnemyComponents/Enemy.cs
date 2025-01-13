using Infrastructure;
using Model.EnemyComponents;
using UnityEngine;

namespace View.EnemyComponents
{
    [RequireComponent(typeof(Animator))]
    public class Enemy : Unit, IPoolable
    {
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private EnemyAttackZone _attackZone;
        [SerializeField] private UnitHelathBar _healthBar;

        [SerializeField] private float _speed = 1;
        [SerializeField] private float _maxHealthPoints = 10;
        [SerializeField] private float _damage = 10;

        private IPool _pool;

        private void OnDisable()
        {
            Dying -= Destroy;
        }

        public void Init(float extraHealth, Particle hit, ParticleSystem death, Transform target, float extraDamage)
        {
            new EnemyParticles(this, death, hit);
            Animator animator = GetComponent<Animator>();
            EnemyAnimator enemyAnimator = new EnemyAnimator();

            enemyAnimator.Init(animator);
            _movement.Init(target, _speed);
            _attackZone.Init(enemyAnimator, _damage + extraDamage);

            Dying += Destroy;
            Init(_maxHealthPoints + extraHealth, _healthBar);
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

            Dying -= Destroy;
            Destroy(gameObject);
        }

        public void HitPlayer()
        {
            _attackZone.HitPlayer();
        }
    }
}