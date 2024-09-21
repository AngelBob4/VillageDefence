using System;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationOfferView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _authorizeButton;
    [SerializeField] private AuthorizationChecker _authorizationChecker;
        
    private Action _onAuthorizeSuccess;
    private Action _onAuthorizeError;
        
    private void Awake()
    {
        _closeButton.onClick.AddListener(Hide);
        _authorizeButton.onClick.AddListener(OnAuthorizeButtonClick);
        _onAuthorizeSuccess += _authorizationChecker.Check;
    }

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(Hide);
        _authorizeButton.onClick.RemoveListener(OnAuthorizeButtonClick);
        _onAuthorizeSuccess -= _authorizationChecker.Check;
    }
        
    public void Show(Action onAuthorizeSuccess, Action onAuthorizeError)
    {
        _onAuthorizeSuccess = onAuthorizeSuccess;
        _onAuthorizeError = onAuthorizeError;
            
        gameObject.SetActive(true);
    }

    private void Hide() => gameObject.SetActive(false);

    private void OnAuthorizeButtonClick()
    {
        void OnAuthorizeSuccess() => _onAuthorizeSuccess?.Invoke();
        void OnAuthorizeError(string error) => _onAuthorizeError?.Invoke();

        Agava.YandexGames.PlayerAccount.Authorize(OnAuthorizeSuccess, OnAuthorizeError);
        Hide();
    }
}