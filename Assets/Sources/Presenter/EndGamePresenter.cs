using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePresenter : IPresenter
{
    private EndGameScreen _endGameScreen;

    public EndGamePresenter(EndGameScreen endGameScreen)
    {
        _endGameScreen = endGameScreen;
    }

    public void Enable()
    {
        _endGameScreen.Close();
        _endGameScreen.RestartButtonClicked += Restart;
    }

    public void Disable()
    {
        _endGameScreen.RestartButtonClicked -= Restart;
    }

    public void Open()
    {
        _endGameScreen.Open();
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}