using YG;

public class Game
{
    private EndGame _endGame;
    private LeaderboardView _leaderboardView;
    private UpgradeScreen _upgradeScreen;
    private int _gameScore = 0;
    private int _rewardScoreForEnemy = 10;
    private AddScore _addScore;
    private EnemyGenerator _enemyGenerator;

    public Game(EndGame endGame, UpgradeScreen upgradeScreen, EnemyGenerator enemyGenerator, AddScore addScore, LeaderboardView leaderboardView)
    {
        _enemyGenerator = enemyGenerator;
        _leaderboardView = leaderboardView;
        _addScore = addScore;
        _endGame = endGame;
        _upgradeScreen = upgradeScreen;
        _gameScore = 0;
        _addScore.UpdateScoreView(_gameScore);
    }

    public void HandlePlayerDeath()
    {
        float openingDelay = 1f;
        YandexGame.savesData.score = _gameScore;
        YandexGame.SaveProgress();
        _leaderboardView.SetPlayerScore(_gameScore);
        _endGame.Open(openingDelay, _gameScore, _enemyGenerator.WaveCounter);
    }

    public void OpenUpgradeScreen(float delay)
    {
        _upgradeScreen.Open(delay);
    }

    public void AddScore()
    {
        _gameScore += _rewardScoreForEnemy;
        _addScore.UpdateScoreView(_gameScore);
        YandexGame.savesData.score = _gameScore;
        YandexGame.SaveProgress();
        _leaderboardView.SetPlayerScore(_gameScore);
    }
}