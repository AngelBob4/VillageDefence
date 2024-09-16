using LeaderboardDemo;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private EndGameScreen _endGameScreen;
    private UpgradeScreen _upgradeScreen;
    private GameAudio _gameAudio;
    private int _gameScore = 0;
    private int _rewardScoreForEnemy = 10;

    public void Init(EndGameScreen endGameScreen, UpgradeScreen upgradeScreen, EnemyFactory enemyFactory, GameAudio gameAudio)
    {
        _endGameScreen = endGameScreen;
        _upgradeScreen = upgradeScreen;
        _gameAudio = gameAudio;

        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;

        _endGameScreen.Close();
        _upgradeScreen.Close();
        enemyFactory.EnemyPool.WaveEnded += OpenUpgradeScreen;
        enemyFactory.EnemyPool.EnemyReturned += AddScore;
    }

    private void OnDisable()
    {
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _gameAudio.ToggleMusic();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _gameAudio.ToggleMusic();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OpenUpgradeScreen()
    {
        _upgradeScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        Agava.YandexGames.Utility.PlayerPrefs.SetInt(Constants.SCORE_PREFS_KEY, _gameScore); 
        Agava.YandexGames.Utility.PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void AddScore()
    {
        _gameScore += _rewardScoreForEnemy;
    }
}