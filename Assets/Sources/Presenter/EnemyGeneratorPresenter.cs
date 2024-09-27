using Cysharp.Threading.Tasks;
using System;

public class EnemyGeneratorPresenter : IPresenter
{
    public event Action WaveEnded;
    public event Action EnemyReturned;

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
        OnEnable();
    }

    public override void OnEnable()
    {
        _enemyPool.EnemyReturned += Release;

        EnemyReturned += _game.AddScore;
        EnemyReturned += _enemyGenerator.ResetProgressionSlider;
        WaveEnded += _game.OpenUpgradeScreen;
        WaveEnded += _enemyGenerator.EndWave;
    }

    public override void OnDisable()
    {
        _enemyPool.EnemyReturned -= Release;

        EnemyReturned -= _game.AddScore;
        EnemyReturned -= _enemyGenerator.ResetProgressionSlider;
        WaveEnded -= _game.OpenUpgradeScreen; 
        WaveEnded -= _enemyGenerator.EndWave;
    }

    public void Release()
    {
        _releasedEnemies++;
        EnemyReturned?.Invoke();

        if (_requiredQuantity == _releasedEnemies)
        {
            UniTask.Delay(1000);
            WaveEnded?.Invoke();
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
}