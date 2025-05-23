using Infrastructure;
using System.Collections;
using UnityEngine;
using View.PlayerComponents;

namespace View.Generators
{
    public class BulletGeneratorView : Generator
    {
        private Bullet _template;
        private Player _player;

        private int _maxBulletsAmount = 15;
        private float _delay = 1f;
        private float _spawnRadius = 7f;

        private BulletPool _bulletPool;
        private WaitForSeconds _spawnDelay;
        private Coroutine _currentCoroutine;

        public void Init(Bullet template, Player player)
        {
            _template = template;
            _player = player;
            _bulletPool = new BulletPool(_template, _maxBulletsAmount);
            _spawnDelay = new WaitForSeconds(_delay);
            StartGeneration();
        }

        public void StartGeneration()
        {
            if (_currentCoroutine == null)
                _currentCoroutine = StartCoroutine(GenerateBullets());
        }

        public void EndGeneration()
        {
            StopCoroutine(_currentCoroutine);
        }

        private IEnumerator GenerateBullets()
        {
            int minRotationAngle = 0;
            int maxRotationAngle = 360;

            while (_player.Health > 0)
            {
                Bullet newBullet = _bulletPool.GetObject();

                if (newBullet != null)
                {
                    SetPositionOnRadius(newBullet.gameObject, _spawnRadius, _player);
                    Quaternion randomRotation = Quaternion.Euler(
                        0,
                        Random.Range(minRotationAngle, maxRotationAngle),
                        0);
                    newBullet.transform.rotation = randomRotation;
                    newBullet.Reset();
                }

                yield return _spawnDelay;
            }
        }
    }
}