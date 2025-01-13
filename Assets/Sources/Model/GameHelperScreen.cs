using Model.EnemyComponents;
using View.UI;
using YG;

namespace Model
{
    public class GameHelperScreen
    {
        private EnemyGenerator _enemyGenerator;
        private readonly PauseService _pauseService;
        private GameHelperScreenView _screenOfGameHelperView;
        private bool firstOpen;

        public GameHelperScreen(EnemyGenerator enemyGenerator,
            PauseService pauseService,
            GameHelperScreenView screenOfGameHelperView)
        {
            _screenOfGameHelperView = screenOfGameHelperView;
            _enemyGenerator = enemyGenerator;
            _pauseService = pauseService;
            firstOpen = YandexGame.savesData.isFirstSession;

            if (firstOpen == true)
            {
                YandexGame.GameReadyAPI();
                Open();
            }
            else
            {
                CloseFirstTime();
            }
        }

        public void Open()
        {
            _screenOfGameHelperView.Open();
            _pauseService.Pause(_screenOfGameHelperView.gameObject);
        }

        public void Close()
        {
            if (firstOpen)
            {
                CloseFirstTime();
                return;
            }

            _screenOfGameHelperView.Close();
            _pauseService.Unpause(_screenOfGameHelperView.gameObject);
        }

        private void CloseFirstTime()
        {
            _screenOfGameHelperView.Close();
            _pauseService.Unpause(_screenOfGameHelperView.gameObject);
            _enemyGenerator.StartWave();
            YandexGame.savesData.isFirstSession = false;
            YandexGame.SaveProgress();
            firstOpen = false;
        }
    }
}