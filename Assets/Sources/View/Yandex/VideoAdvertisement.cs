using UnityEngine;
using YG;

public class VideoAdvertisement : MonoBehaviour
{
    private PauseService _pauseService;

    public void Init(PauseService pauseService)
    {
        _pauseService = pauseService;
    }

    public void ShowVideo() => YandexGame.RewVideoShow(0);

    public void ShowInterstitial() => YandexGame.RewVideoShow(0);


    public void OnOpenCallback()
    {
        _pauseService.Pause(gameObject);
    }

    public void OnCloseCallback()
    {
        _pauseService.Unpause(gameObject);
    }

    public void OnCloseCallback(bool onClose)
    {
        _pauseService.Unpause(gameObject);
    }
}