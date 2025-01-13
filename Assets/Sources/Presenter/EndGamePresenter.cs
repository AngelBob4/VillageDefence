using Infrastructure;
using Model;
using UnityEngine.SceneManagement;
using View.UI;

namespace Presenter
{
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
            _endGame.ScreenOpenedWithDelay += Open;
        }

        public void Disable()
        {
            _view.RestartButtonClicked -= Restart;
            _endGame.ScreenOpenedWithDelay -= Open;
        }

        private void Open(float delay, int score, int waves)
        {
            _view.Open(delay, score, waves);
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}