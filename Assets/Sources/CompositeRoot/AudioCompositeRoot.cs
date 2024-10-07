using UnityEngine;

public class AudioCompositeRoot : CompositeRoot
{
    [SerializeField] private GameAudio _gameAudio;
    [SerializeField] private AudioButton _audioButton;

    public override void Compose()
    {
        _audioButton.Init(_gameAudio);
    }
}