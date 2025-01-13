using System;
using UnityEngine;
using View.EnemyComponents;
using View.PlayerComponents;

namespace Model
{
    public class Gun
    {
        private readonly AudioSource _shoot;
        private readonly AudioSource _bulletPickUp;
        private float _currentReloadTime = 0;
        private float _reloadTime;
        private float _damage;
        private float _percentOfLifesteal = 0;
        private Player _player;

        public Gun(float reloadTime, float damage, Player player, AudioSource shoot, AudioSource bulletPickUp)
        {
            _reloadTime = reloadTime;
            _damage = damage;
            _player = player;
            _shoot = shoot;
            _bulletPickUp = bulletPickUp;
        }

        public event Action<Enemy> Shooting;

        private float Lifesteal => _damage * _percentOfLifesteal / 100;

        public void BulletPickUpSound()
        {
            _bulletPickUp.Play();
        }

        public void Shoot(Enemy enemy)
        {
            if (ReadyToShoot())
            {
                Shooting?.Invoke(enemy);
                _currentReloadTime = _reloadTime;
                enemy.GetDamage(_damage);
                _player.Heal(Lifesteal);
                _shoot.Play();
            }
        }

        public void Tick(float time)
        {
            if (_currentReloadTime < 0)
            {
                _currentReloadTime = 0;
            }
            else
            {
                _currentReloadTime -= time;
            }
        }

        public void AppendDamage(float percentOfDamage)
        {
            if (percentOfDamage >= 0)
                _damage += _damage * percentOfDamage / 100;
        }

        public void AppendLifesteal(float percentOfLifesteal)
        {
            if (percentOfLifesteal >= 0)
                _percentOfLifesteal += percentOfLifesteal;
        }

        private bool ReadyToShoot() => _currentReloadTime <= 0;
    }
}