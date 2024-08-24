public class EnemyGenerator
{
    private EnemyGeneratorView _enemyGeneratorView;
    private float _currentTime = 0;
    private bool _isWaveStarting = false;

    private int _waveCounter = 0;
    private int _startAmountOfEnemies = 2;
    private int _timeBetweenWaves = 15;

    public EnemyGenerator(EnemyGeneratorView enemyGeneratorView)
    {
        _enemyGeneratorView = enemyGeneratorView;
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

    public void Tick(float time)
    {
        if (_isWaveStarting)
        {
            _currentTime += time;

            if (_currentTime >= _timeBetweenWaves)
            {
                _enemyGeneratorView.StartNextWave(_startAmountOfEnemies + _waveCounter);
                _isWaveStarting = false;
                _waveCounter++;
            }
        }
    }
}