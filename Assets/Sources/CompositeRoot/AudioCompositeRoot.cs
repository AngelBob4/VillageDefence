using Infrastructure;
using UnityEngine;
using View;
using View.UI;

namespace Root
{
    public class AudioCompositeRoot : CompositeRoot
    {
        [SerializeField] private GameAudio _gameAudio;
        [SerializeField] private AudioButton _audioButton;

        public override void Compose()
        {
            _audioButton.Init(_gameAudio);
        }
    }
}