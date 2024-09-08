using UnityEngine;

public class Game : MonoBehaviour
{
    private StartScreen _startScreen;
    private EndGameScreen _endGameScreen;
    private UpgradeScreen _upgradeScreen;
    private GameAudio _gameAudio;

    public void Init(StartScreen startScreen, EndGameScreen endGameScreen, UpgradeScreen upgradeScreen, EnemyFactory enemyFactory, GameAudio gameAudio)
    {
        _startScreen = startScreen;
        _endGameScreen = endGameScreen;
        _upgradeScreen = upgradeScreen;
        _gameAudio = gameAudio;

        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;

        _endGameScreen.Close();
        _startScreen.Close();
        _upgradeScreen.Close();
        enemyFactory.EnemyPool.WaveEnded += OpenUpgradeScreen;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
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

    private void OpenUpgradeScreen()
    {
        _upgradeScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }
}