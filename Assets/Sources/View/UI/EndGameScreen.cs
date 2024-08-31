using System;
using UnityEngine.UI;

public class EndGameScreen : Window
{
    private Button _actionButton;
    public event Action RestartButtonClicked;

    public void Init(Button button)
    {
        _actionButton = button;
        _actionButton.onClick.AddListener(OnButtonClick);
        base.Init();
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}