using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

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
#if !UNITY_EDITOR
        int firstOpen = Agava.YandexGames.Utility.PlayerPrefs.GetInt(Constants.FIRST_OPEN_KEY, Constants.TRUE_VALUE);

        if (firstOpen == Constants.TRUE_VALUE)
            Open();
        else
            _game.Resume();
#endif
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
#if !UNITY_EDITOR
        Agava.YandexGames.Utility.PlayerPrefs.SetInt(Constants.FIRST_OPEN_KEY, Constants.FALSE_VALUE);
        Agava.YandexGames.Utility.PlayerPrefs.Save();
#endif
    }
}