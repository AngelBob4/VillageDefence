using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICompositeRoot : CompositeRoot
{
    [SerializeField] private GameAudio _gameAudio;
    [SerializeField] private AudioButton _audioButton;

    public override void Compose()
    {
        _audioButton.Init(_gameAudio);
    }
}