using System.Collections.Generic;
using Infrastructure;
using UnityEngine;
using View.PlayerComponents;

namespace View.EnemyComponents
{
    public class EnemyFactory : MonoBehaviour
    {
        private EnemyPool _enemyPool;
        private Player _player;
        private Particle _hit;
        private ParticleSystem _death;
        private float _extraDamage = 0f;
        private float _extraHealth = 0f;

        public EnemyPool EnemyPool => _enemyPool;

        public void Init(List<Enemy> templates, Player player, Particle hit, ParticleSystem death)
        {
            _enemyPool = new EnemyPool(templates);
            _player = player;
            _hit = hit;
            _death = death;
        }

        public void ResetEnemyParametrs(float extraMaxHealth, float extraDamage)
        {
            _extraHealth += extraMaxHealth;
            _extraDamage += extraDamage;
        }

        public Enemy Create()
        {
            Enemy enemy = _enemyPool.GetObject();
            enemy.Init(_extraHealth, _hit, _death, _player.transform, _extraDamage);
            return enemy;
        }
    }
}