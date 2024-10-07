using UnityEngine;
using YG;
using UnityEngine.Audio;

public class GameAudio : MonoBehaviour
{
    private const int AUDIO_ACTIVE = 1;
    private const int AUDIO_MUTED = -1;

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
            _audioMixer.audioMixer.SetFloat(Constants.MASTER_VOLUME_KEY, _minVolume);
            _musicActive = false;
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(Constants.MASTER_VOLUME_KEY, _masterVolume);
            _musicActive = true;
        }

        ResetPrefs();
    }

    public void TurnOn()
    {
        _audioMixer.audioMixer.SetFloat(Constants.MASTER_VOLUME_KEY, _masterVolume);
        _audioButton.TurnOnAudio();
    }

    public void TurnOff()
    {
        _audioMixer.audioMixer.SetFloat(Constants.MASTER_VOLUME_KEY, _minVolume);
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