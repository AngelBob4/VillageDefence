using Agava.YandexGames;

public class EnemyGenerator
{
    private TimeToWave _timeToWave;
    private EnemyGeneratorView _enemyGeneratorView;
    private EnemyFactory _enemyFactory;
    private VideoAdvertisement _videoAdvertisement;

    private float _currentTime = 0;
    private bool _isWaveStarting = false;
    private int _waveCounter = 0;
    private int _startAmountOfEnemies = 1;
    private int _timeBetweenWaves = 5;

    public int WaveCounter => _waveCounter;

    public EnemyGenerator(EnemyGeneratorView enemyGeneratorView, TimeToWave timeToWave, EnemyFactory enemyFactory, VideoAdvertisement videoAdvertisement)
    {
        _videoAdvertisement = videoAdvertisement;
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
            _videoAdvertisement.ShowInterstitial();
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
                _waveCounter++;
                _enemyGeneratorView.StartNextWave(_startAmountOfEnemies + _waveCounter);
                _isWaveStarting = false;
            }
        }
    }
}