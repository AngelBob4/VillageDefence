using UnityEngine.SceneManagement;

public class EndGamePresenter : IPresenter
{
    private EndGameScreen _view;
    private PauseService _pauseService;
    private EndGame _endGame;

    public EndGamePresenter(EndGameScreen endGameScreen, PauseService pauseService, EndGame endGame)
    {
        _pauseService = pauseService;
        _view = endGameScreen;
        _endGame = endGame;
    }

    public void Enable()
    {
        _view.RestartButtonClicked += Restart;
        _view.ScreenOpened += OnScreenOpened;
        _endGame.ScreenOpenedWithDelay += Open;
    }

    public void Disable()
    {
        _view.RestartButtonClicked -= Restart;
        _view.ScreenOpened -= OnScreenOpened;
        _endGame.ScreenOpenedWithDelay -= Open;
    }

    public void Open(float delay, int score, int waves)
    {
        _view.Open(delay, score, waves);
    }

    private void OnScreenOpened() => _pauseService.Pause(_view.gameObject);

    private void Restart()
    {
        _pauseService.Unpause(_view.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}