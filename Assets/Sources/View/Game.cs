using UnityEngine;

public class Game : MonoBehaviour
{
    private StartScreen _startScreen;
    private EndGameScreen _endGameScreen;
    private EnemyGenerator _enemyGenerator;

    public void Init(EnemyGenerator enemyGenerator, StartScreen startScreen, EndGameScreen endGameScreen)
    {
        _enemyGenerator = enemyGenerator;
        _startScreen = startScreen;
        _endGameScreen = endGameScreen;

        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
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