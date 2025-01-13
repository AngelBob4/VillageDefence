using System;
using Infrastructure;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using View.Yandex;
using YG;

namespace View
{
    public class AddNotificationView : MonoBehaviour
    {
        [SerializeField] private Text _timeToStartAdd;

        private IPresenter _presenter;
        private float _delay = 1f;

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
            float timeToAdd = Constants.AddNotificationDelay;

            while (timeToAdd > 0)
            {
                _timeToStartAdd.text = timeToAdd.ToString();
                await UniTask.Delay(TimeSpan.FromSeconds(_delay), ignoreTimeScale: true);
                timeToAdd--;
            }
        }
    }
}