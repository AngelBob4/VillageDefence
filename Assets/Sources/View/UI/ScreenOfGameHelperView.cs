using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenOfGameHelperView : MonoBehaviour
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private CanvasGroup _windowGroup;

    private IPresenter _presenter;

    public event Action OnOpenButtonClicked;
    public event Action OnExitButtonClicked;

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

    private void OnOpenButtonClick() => OnOpenButtonClicked?.Invoke();
    private void OnExitButtonClick() => OnExitButtonClicked?.Invoke();

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
}