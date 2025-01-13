using Infrastructure;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.Yandex.Leaderboard
{
    public class AuthorizationOfferView : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _authorizeButton;
        [SerializeField] private AuthorizationChecker _authorizationChecker;
        [SerializeField] private GameObject _container;

        private IPresenter _presenter;

        public event Action AuthorizeButtonClicked;
        public event Action OpenButtonClicked;
        public event Action CloseButtonClicked;

        public void Init(IPresenter presenter)
        {
            gameObject.SetActive(false);
            _presenter = presenter;
            gameObject.SetActive(true);
        }

        private void Awake()
        {
            _openButton.onClick.AddListener(OnOpen);
            _closeButton.onClick.AddListener(OnClose);
            _authorizeButton.onClick.AddListener(OnAuthorizeButtonClick);
        }

        private void OnDestroy()
        {
            _openButton.onClick.RemoveListener(OnOpen);
            _closeButton.onClick.RemoveListener(OnClose);
            _authorizeButton.onClick.RemoveListener(OnAuthorizeButtonClick);
        }

        private void OnEnable() => _presenter.Enable();

        private void OnDisable() => _presenter.Disable();

        public void Show()
        {
            _container.SetActive(true);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }

        private void OnOpen()
        {
            OpenButtonClicked?.Invoke();
        }

        private void OnClose()
        {
            CloseButtonClicked?.Invoke();
        }

        private void OnAuthorizeButtonClick()
        {
            AuthorizeButtonClicked?.Invoke();
        }
    }
}