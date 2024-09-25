using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private EndGameScreen _endGameScreen;
    private PauseService _pauseService;
    private LeaderboardView _leaderboardView;
    private UpgradeScreen _upgradeScreen;
    private GameAudio _gameAudio;
    private int _gameScore = 0;
    private int _rewardScoreForEnemy = 10;
    private AddScore _addScore;

    public void Init(EndGameScreen endGameScreen, UpgradeScreen upgradeScreen, EnemyFactory enemyFactory, GameAudio gameAudio, AddScore addScore, LeaderboardView leaderboardView)
    {
        _leaderboardView = leaderboardView;
        _addScore = addScore;
        _endGameScreen = endGameScreen;
        _upgradeScreen = upgradeScreen;
        _gameAudio = gameAudio;
        _pauseService = new PauseService();

        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        enemyFactory.EnemyPool.WaveEnded += OpenUpgradeScreen;
        enemyFactory.EnemyPool.EnemyReturned += AddScore;

        _endGameScreen.Close();
        _upgradeScreen.Close();
#if !UNITY_EDITOR
        Agava.YandexGames.Utility.PlayerPrefs.SetInt(Constants.SCORE_PREFS_KEY, _gameScore); 
        Agava.YandexGames.Utility.PlayerPrefs.Save();
        _gameScore = Agava.YandexGames.Utility.PlayerPrefs.GetInt(Constants.SCORE_PREFS_KEY);
#endif
    }

    private void OnDisable()
    {
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    public void Pause(GameObject gameObject)
    {
        _pauseService.Pause(gameObject);
        Time.timeScale = 0;
    }

    public void Resume(GameObject gameObject)
    {
        if (_pauseService.Unpause(gameObject))
            Time.timeScale = 1;
    }

    public void OnGameOver()
    {
#if !UNITY_EDITOR
        Agava.YandexGames.Utility.PlayerPrefs.SetInt(Constants.SCORE_PREFS_KEY, 0);
        Agava.YandexGames.Utility.PlayerPrefs.Save();
        _leaderboardView.SetPlayerScore(_gameScore);
#endif

        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OpenUpgradeScreen()
    {
        _upgradeScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void AddScore()
    {
        _gameScore += _rewardScoreForEnemy;
        _addScore.UpdateScoreView(_gameScore);
#if !UNITY_EDITOR
        Agava.YandexGames.Utility.PlayerPrefs.SetInt(Constants.SCORE_PREFS_KEY, _gameScore);
        Agava.YandexGames.Utility.PlayerPrefs.Save();
        _leaderboardView.SetPlayerScore(_gameScore);
#endif
    }
}