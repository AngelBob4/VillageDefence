using UnityEngine;
using UnityEngine.UI;

public class UICompositeRoot : CompositeRoot
{
    [SerializeField] private GameAudio _gameAudio;
    [SerializeField] private AudioButton _audioButton;
    [SerializeField] private Game _game;
    [SerializeField] private Button _exitButton;
    [SerializeField] private ScreenOfGameHelper _screenOfGameHelper;

    public override void Compose()
    {
        _audioButton.Init(_gameAudio);
        _screenOfGameHelper.Init(_game, _exitButton);
    }
}