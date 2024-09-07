using UnityEngine;

public class Game : MonoBehaviour
{
    private StartScreen _startScreen;
    private EndGameScreen _endGameScreen;
    private EnemyGenerator _enemyGenerator;
    private UpgradeScreen _upgradeScreen;

    public void Init(EnemyGeneratorCompositeRoot enemyGeneratorCompositeRoot, StartScreen startScreen, EndGameScreen endGameScreen, UpgradeScreen upgradeScreen)
    {
        _enemyGenerator = enemyGeneratorCompositeRoot.EnemyGenerator;
        _startScreen = startScreen;
        _endGameScreen = endGameScreen;
        _upgradeScreen = upgradeScreen;

        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;

        _endGameScreen.Close();
        _startScreen.Close();
        _upgradeScreen.Close();
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
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