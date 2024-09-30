using System;
using UnityEngine.UI;
using UnityEngine;

public class EndGameScreen : Window
{
    [SerializeField] private Button _actionButton;

    private IPresenter _presenter;

    public event Action RestartButtonClicked;

    public void Init(IPresenter presenter)
    {
        gameObject.SetActive(false);
        _presenter = presenter;
        gameObject.SetActive(true);
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnEnable()
    {
        _presenter?.Enable();
    }

    private void OnDisable()
    {
        _presenter?.Disable();
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}