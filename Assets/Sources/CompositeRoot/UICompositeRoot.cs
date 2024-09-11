using UnityEngine;
using UnityEngine.UI;

public class UICompositeRoot : CompositeRoot
{
    [SerializeField] private GameAudio _gameAudio;
    [SerializeField] private AudioButton _audioButton;
    [SerializeField] private Game _game;
    [SerializeField] private Button _exitButton;
    [SerializeField] private ScreenOfGameHelper _screenOfGameHelper;
    [SerializeField] private EnemyGeneratorCompositeRoot _enemyGeneratorCompositeRoot;
    [SerializeField] private VideoAdvertisement _videoAdd;

    public override void Compose()
    {
        _audioButton.Init(_gameAudio);
        _screenOfGameHelper.Init(_game, _exitButton, _enemyGeneratorCompositeRoot);
        _videoAdd.Init(_game);
    }
}