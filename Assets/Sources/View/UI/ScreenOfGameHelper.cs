using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenOfGameHelper : MonoBehaviour
{
    private Game _game;
    private Button _exitButton;
    private CanvasGroup _windowGroup;

    public void Init(Game game, Button exitButton)
    {
        _game = game;
        _exitButton = exitButton;
        _windowGroup = GetComponent<CanvasGroup>(); 
        _exitButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(Close);
    }

    public void Open()
    {
        _windowGroup.alpha = 1f;
        _windowGroup.blocksRaycasts = true;
        _game.Pause();
    }

    private void Close()
    {
        _windowGroup.alpha = 0f;
        _windowGroup.blocksRaycasts = false;
        _game.Resume();
    }
}