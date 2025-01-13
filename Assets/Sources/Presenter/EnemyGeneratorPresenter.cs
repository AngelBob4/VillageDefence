using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure;
using Model.EnemyComponents;
using UnityEngine;
using UnityEngine.UI;

namespace Presenter
{
    public class EnemyGeneratorPresenter : IPresenter
    {
        private EnemyPool _enemyPool;
        private EnemyGenerator _enemyGenerator;
        private Game _game;
        private Text _waveCompleted;
        private int _requiredQuantity = 0;
        private int _releasedEnemies = 0;

        public EnemyGeneratorPresenter(EnemyPool enemyPool, Game game, EnemyGenerator enemyGenerator, Text waveCompleted)
        {
            _waveCompleted = waveCompleted;
            _enemyGenerator = enemyGenerator;
            _enemyPool = enemyPool;
            _game = game;
            Enable();
        }

        public int ReleasedEnemies => _releasedEnemies;

        public void Enable()
        {
            _enemyPool.EnemyReturned += Release;
        }

        public void Disable()
        {
            _enemyPool.EnemyReturned -= Release;
        }

        public void Reset(int requiredQuantity)
        {
            if (requiredQuantity >= 0)
            {
                _releasedEnemies = 0;
                _requiredQuantity = requiredQuantity;
            }
        }

        private void Release()
        {
            _releasedEnemies++;
            _game.AddScore();
            _enemyGenerator.ResetProgressionSlider();

            if (_requiredQuantity == _releasedEnemies)
            {
                EndWave();
            }
        }

        private async void EndWave()
        {
            float textDelay = 1f;
            float closingTimeScale = 2f;

            _waveCompleted.gameObject.SetActive(true);
            _waveCompleted.rectTransform.localScale = Vector3.zero;
            _waveCompleted.rectTransform.DOScale(1f, textDelay);
            await UniTask.Delay(TimeSpan.FromSeconds(textDelay), ignoreTimeScale: false);
            _waveCompleted.rectTransform.DOScale(0f, textDelay);
            await UniTask.Delay(TimeSpan.FromSeconds(textDelay / closingTimeScale), ignoreTimeScale: false);

            _game.OpenUpgradeScreen(textDelay);
            await UniTask.Delay(TimeSpan.FromSeconds(2), ignoreTimeScale: false);
            _enemyGenerator.EndWave();
        }
    }
}