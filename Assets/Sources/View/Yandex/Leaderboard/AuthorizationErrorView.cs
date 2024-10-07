using System;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationErrorView : MonoBehaviour
{
    [SerializeField] private Button _confirmButton;
    [SerializeField] private GameObject _container;

    private IPresenter _presenter;

    public event Action OnOpen;
    public event Action OnCloseButtonClicked;

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
        OnOpen?.Invoke();
    }

    private void Hide() 
    {
        _container.SetActive(false);
        OnCloseButtonClicked?.Invoke();
    } 
}