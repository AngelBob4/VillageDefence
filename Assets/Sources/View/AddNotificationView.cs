using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AddNotificationView : MonoBehaviour
{
    [SerializeField] private Text _timeToStartAdd;

    private IPresenter _presenter;
    private WaitForSeconds _delay = new WaitForSeconds(1f);

    public void Init(IPresenter presenter)
    {
        _presenter = presenter;
    }

    private void OnEnable()
    {
        YandexGame.CloseFullAdEvent += OnCloseFullAdEvent;
        _presenter.Enable();
        StartNotification();
    }

    private void OnDisable()
    {
        YandexGame.CloseFullAdEvent -= OnCloseFullAdEvent;
        _presenter.Disable();
    }

    private void OnCloseFullAdEvent()
    {
        gameObject.SetActive(false);
    }

    private async void StartNotification()
    {
        float timeToAdd = Constants.ADD_NOTIFICATION_DELAY;

        while (timeToAdd > 0)
        {
            _timeToStartAdd.text = timeToAdd.ToString();
            await UniTask.Delay(TimeSpan.FromSeconds(1f), ignoreTimeScale: true);
            timeToAdd--;
        }
    }
}