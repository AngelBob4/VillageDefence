using UnityEngine;
using YG;

public class VideoAdvertisement : MonoBehaviour
{
    private PauseService _pauseService;

    public void Init(PauseService pauseService)
    {
        _pauseService = pauseService;
    }

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += OnOpenFullAdEvent;
        YandexGame.CloseFullAdEvent += OnCloseFullAdEvent;
    }

    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= OnOpenFullAdEvent;
        YandexGame.CloseFullAdEvent -= OnCloseFullAdEvent;
    }

    public void ShowVideo() => YandexGame.RewVideoShow(0);

    public void ShowInterstitial() => YandexGame.FullscreenShow();

    public void OnOpenFullAdEvent()
    {
        _pauseService.Pause(gameObject);
    }

    public void OnCloseFullAdEvent()
    {
        _pauseService.Unpause(gameObject);
    }
}