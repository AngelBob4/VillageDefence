using UnityEngine;
using YG;

public class ScreenOfGameHelper
{
    private EnemyGenerator _enemyGenerator;
    private readonly PauseService _pauseService;
    private ScreenOfGameHelperView _screenOfGameHelperView;
    bool firstOpen;

    public ScreenOfGameHelper(EnemyGenerator enemyGenerator, PauseService pauseService, ScreenOfGameHelperView screenOfGameHelperView)
    {
        _screenOfGameHelperView = screenOfGameHelperView;
        _enemyGenerator = enemyGenerator;
        _pauseService = pauseService;
        firstOpen = YandexGame.savesData.isFirstSession;

        if (firstOpen == true)
            Open();
        else
            CloseFirstTime();
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