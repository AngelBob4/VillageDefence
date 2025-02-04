using View;
using View.Generators;

namespace Model.EnemyComponents
{
    public class EnemyGenerator
    {
        private TimeToWave _timeToWave;
        private EnemyGeneratorView _enemyGeneratorView;
        private ProgressionSlider _progressionSlider;

        private float _currentTime = 0;
        private bool _isWaveStarting = false;
        private int _waveCounter = 0;
        private int _startAmountOfEnemies = 1;
        private int _timeBetweenWaves = 3;

        public EnemyGenerator(EnemyGeneratorView enemyGeneratorView,
            TimeToWave timeToWave,
            ProgressionSlider progressionSlider)
        {
            _progressionSlider = progressionSlider;
            _enemyGeneratorView = enemyGeneratorView;
            _timeToWave = timeToWave;
        }

        public int WaveCounter => _waveCounter;

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
                    ResetProgressionSlider();
                }
            }
        }

        public void ResetProgressionSlider()
        {
            _progressionSlider.ResetValues(
                _enemyGeneratorView.EnemyGeneratorPresenter.ReleasedEnemies,
                _startAmountOfEnemies + _waveCounter,
                _waveCounter);
        }
    }
}