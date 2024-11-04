using UnityEngine;
using YG;
using Cysharp.Threading.Tasks;

public class VideoAdvertisement : MonoBehaviour
{
    private PauseService _pauseService;

    public void Init(PauseService pauseService)
    {
        _pauseService = pauseService;
    }

    private void OnEnable()
    {
        YandexGame.CloseFullAdEvent += OnCloseFullAdEvent;
    }

    private void OnDisable()
    {
        YandexGame.CloseFullAdEvent -= OnCloseFullAdEvent;
    }

    public void ShowVideo() => YandexGame.RewVideoShow(0);

    public void ShowInterstitial()
    {
        _pauseService.Pause(gameObject);
        YandexGame.FullscreenShow();
    }

    public void OnCloseFullAdEvent()
    {
        _pauseService.Unpause(gameObject);
    }
}