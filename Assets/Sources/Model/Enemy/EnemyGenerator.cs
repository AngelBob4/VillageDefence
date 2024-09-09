using Agava.YandexGames;

public class EnemyGenerator
{
    private TimeToWave _timeToWave;
    private EnemyGeneratorView _enemyGeneratorView;
    private EnemyFactory _enemyFactory;

    private float _currentTime = 0;
    private bool _isWaveStarting = false;
    private int _waveCounter = 0;
    private int _startAmountOfEnemies = 1;
    private int _timeBetweenWaves = 5;

    public EnemyGenerator(EnemyGeneratorView enemyGeneratorView, TimeToWave timeToWave, EnemyFactory enemyFactory)
    {
        _enemyGeneratorView = enemyGeneratorView;
        _timeToWave = timeToWave;
        _enemyFactory = enemyFactory;
        _enemyFactory.EnemyPool.WaveEnded += EndWave;
    }

    public void StartWithDelay()
    {
        _currentTime = 0;
        _isWaveStarting = true;
    }

    public void StartWave()
    {
        _currentTime = _timeBetweenWaves;
        _isWaveStarting = true;
    }

    public void EndWave()
    {
        if (_waveCounter % 10 == 0)
        {
            InterstitialAd.Show();
        }

        StartWithDelay();
    }

    public void Tick(float time)
    {
        if (_isWaveStarting)
        {
            _currentTime += time;
            float timeToNextWave = _timeBetweenWaves - _currentTime;
            _timeToWave.ResetTime(timeToNextWave);

            if (_currentTime >= _timeBetweenWaves)
            {
                _enemyGeneratorView.StartNextWave(_startAmountOfEnemies + _waveCounter);
                _isWaveStarting = false;
                _waveCounter++;
            }
        }
    }
}