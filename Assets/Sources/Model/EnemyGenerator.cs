public class EnemyGenerator
{
    private EnemyGeneratorView _enemyGeneratorView;
    private int _timeBetweenWaves;
    private float _currentTime = 0;
    private bool _isWaveStarting = false;

    public EnemyGenerator(EnemyGeneratorView enemyGeneratorView, int timeBetweenWaves)
    {
        _enemyGeneratorView = enemyGeneratorView;
        _timeBetweenWaves = timeBetweenWaves;
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
                _enemyGeneratorView.StartNextWave();
                _isWaveStarting = false;
            }
        }
    }
}