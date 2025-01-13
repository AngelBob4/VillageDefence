using Infrastructure;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.Yandex.Leaderboard
{
    public class AuthorizationErrorView : MonoBehaviour
    {
        [SerializeField] private Button _confirmButton;
        [SerializeField] private GameObject _container;

        private IPresenter _presenter;

        public event Action Opening;
        public event Action CloseButtonClicked;

        public void Init(IPresenter presenter)
        {
            gameObject.SetActive(false);
            _presenter = presenter;
            gameObject.SetActive(true);
        }

        private void Awake() => _confirmButton.onClick.AddListener(Hide);

        private void OnDestroy() => _confirmButton.onClick.RemoveListener(Hide);

        private void OnEnable() => _presenter.Enable();

        private void OnDisable() => _presenter.Disable();

        public void Show()
        {
            _container.SetActive(true);
            Opening?.Invoke();
        }

        private void Hide()
        {
            _container.SetActive(false);
            CloseButtonClicked?.Invoke();
        }
    }
}