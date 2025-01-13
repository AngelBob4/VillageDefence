using UnityEngine;
using UnityEngine.Audio;
using View.UI;
using View.Yandex;
using YG;

namespace View
{
    public class GameAudio : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _audioMixer;
        [SerializeField] private AudioSource _musicAudioSource;
        [SerializeField] private AudioButton _audioButton;

        private float _masterVolume = 0;
        private float _minVolume = -80f;
        private bool _musicActive = true;

        public bool MusicActive => _musicActive;

        private void Start()
        {
            if (YandexGame.savesData.isFirstSession)
            {
                _musicActive = true;
                return;
            }

            _musicActive = YandexGame.savesData.isAudioActive;

            ResumeAudio();
        }

        public void ToggleMusic()
        {
            if (_musicActive)
            {
                _audioMixer.audioMixer.SetFloat(Constants.MasterVolume, _minVolume);
                _musicActive = false;
            }
            else
            {
                _audioMixer.audioMixer.SetFloat(Constants.MasterVolume, _masterVolume);
                _musicActive = true;
            }

            ResetPrefs();
        }

        public void TurnOn()
        {
            _audioMixer.audioMixer.SetFloat(Constants.MasterVolume, _masterVolume);
            _audioButton.TurnOnAudio();
        }

        public void TurnOff()
        {
            _audioMixer.audioMixer.SetFloat(Constants.MasterVolume, _minVolume);
            _audioButton.TurnOffAudio();
        }

        public void ResumeAudio()
        {
            if (_musicActive)
                TurnOn();
            else
                TurnOff();
        }

        private void ResetPrefs()
        {
            YandexGame.savesData.isAudioActive = _musicActive;
            YandexGame.SaveProgress();
        }
    }
}