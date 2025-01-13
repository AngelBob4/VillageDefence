using System;
using UnityEngine;
using UnityEngine.UI;
using Infrastructure;

namespace View.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameHelperScreenView : MonoBehaviour
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private CanvasGroup _windowGroup;

        private IPresenter _presenter;

        public event Action OpenButtonClicked;
        public event Action ExitButtonClicked;

        public void Init(IPresenter presenter)
        {
            gameObject.SetActive(false);
            _presenter = presenter;
            gameObject.SetActive(true);
            _windowGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            _presenter.Enable();
            _openButton.onClick.AddListener(OnOpenButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnDisable()
        {
            _presenter.Disable();
            _openButton.onClick.RemoveListener(OnOpenButtonClick);
            _exitButton.onClick.RemoveListener(OnExitButtonClick);
        }

        public void Open()
        {
            _windowGroup.alpha = 1f;
            _windowGroup.blocksRaycasts = true;
        }

        public void Close()
        {
            _windowGroup.alpha = 0f;
            _windowGroup.blocksRaycasts = false;
        }

        private void OnOpenButtonClick() => OpenButtonClicked?.Invoke();

        private void OnExitButtonClick() => ExitButtonClicked?.Invoke();
    }
}