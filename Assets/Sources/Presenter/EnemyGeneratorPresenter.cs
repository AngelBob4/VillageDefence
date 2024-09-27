using Cysharp.Threading.Tasks;
using System;

public class EnemyGeneratorPresenter : IPresenter
{
    private EnemyPool _enemyPool;
    private EnemyGenerator _enemyGenerator;
    private Game _game;
    private int _requiredQuantity = 0;
    private int _releasedEnemies = 0;

    public int ReleasedEnemies => _releasedEnemies;

    public EnemyGeneratorPresenter(EnemyPool enemyPool, Game game, EnemyGenerator enemyGenerator)
    {
        _enemyGenerator = enemyGenerator;
        _enemyPool = enemyPool;
        _game = game;
        Enable();
    }

    public void Enable()
    {
        _enemyPool.EnemyReturned += Release;
    }

    public void Disable()
    {
        _enemyPool.EnemyReturned -= Release;
    }

    public void Release()
    {
        _releasedEnemies++;
        _game.AddScore();
        _enemyGenerator.ResetProgressionSlider();

        if (_requiredQuantity == _releasedEnemies)
        {
            EndWave();
        }
    }

    public void Reset(int requiredQuantity)
    {
        if (requiredQuantity >= 0)
        {
            _releasedEnemies = 0;
            _requiredQuantity = requiredQuantity;
        }
    }

    private async void EndWave()
    {
        _game.OpenUpgradeScreen(1f);
        await UniTask.Delay(TimeSpan.FromSeconds(2), ignoreTimeScale: false);
        _enemyGenerator.EndWave();
    }
}