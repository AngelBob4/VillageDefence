using Model;
using UnityEngine;

namespace View.Yandex
{
    public class CheckingFocus : MonoBehaviour
    {
        private PauseService _pauseService;

        public void Init(PauseService pauseService)
        {
            _pauseService = pauseService;
        }

        private void OnEnable()
        {
            Application.focusChanged += OnInBackgroundChangeApp;
        }

        private void OnDisable()
        {
            Application.focusChanged -= OnInBackgroundChangeApp;
        }

        private void OnInBackgroundChangeApp(bool inApp)
        {
            PauseGame(!inApp);
        }

        private void PauseGame(bool value)
        {
            if (value)
                _pauseService.Pause(gameObject);
            else
                _pauseService.Unpause(gameObject);
        }
    }
}