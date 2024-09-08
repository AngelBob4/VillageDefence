using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenOfGameHelper : MonoBehaviour
{
    private Game _game;
    private Button _exitButton;
    private CanvasGroup _windowGroup;
    private EnemyGeneratorCompositeRoot _enemyGeneratorCompositeRoot;

    public void Init(Game game, Button exitButton, EnemyGeneratorCompositeRoot enemyGeneratorCompositeRoot)
    {
        _enemyGeneratorCompositeRoot = enemyGeneratorCompositeRoot;
        _game = game;
        _exitButton = exitButton;
        _windowGroup = GetComponent<CanvasGroup>();
        _exitButton.onClick.AddListener(CloseFirstTime);
        Open();
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

    private void CloseFirstTime()
    {
        _enemyGeneratorCompositeRoot.EnemyGenerator.StartWave();
        Close();
        _exitButton.onClick.RemoveListener(CloseFirstTime);
        _exitButton.onClick.AddListener(Close);
    }
}