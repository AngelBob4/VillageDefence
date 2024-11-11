using System;
using UnityEngine.UI;

public class StartScreen : Window
{
    private Button _actionButton;

    public event Action PlayButtonClicked;

    public void Init(Button button)
    {
        _actionButton = button;
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}