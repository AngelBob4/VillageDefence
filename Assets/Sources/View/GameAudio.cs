using UnityEngine;
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

    private void Awake()
    {

    }

    private void Start()
    {
#if !UNITY_EDITOR
        int active = Agava.YandexGames.Utility.PlayerPrefs.GetInt(Constants.AUDIO_ACTIVE_PREFS_KEY);
        _musicActive = active == AUDIO_ACTIVE;
#endif
        ResumeAudio();
    }

    public void ToggleMusic()
    {
        if (_musicActive)
        {
            _audioMixer.audioMixer.SetFloat(Constants.MASTER_VOLUME, _minVolume);
            _musicActive = false;
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(Constants.MASTER_VOLUME, _masterVolume);
            _musicActive = true;
        }

        ResetPrefs();
    }

    public void TurnOn()
    {
        _audioMixer.audioMixer.SetFloat(Constants.MASTER_VOLUME, _masterVolume);
        _audioButton.TurnOnAudio();
    }

    public void TurnOff()
    {
        _audioMixer.audioMixer.SetFloat(Constants.MASTER_VOLUME, _minVolume);
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
#if !UNITY_EDITOR
        int audioActive = _musicActive ? AUDIO_ACTIVE : AUDIO_MUTED;
        Agava.YandexGames.Utility.PlayerPrefs.SetInt(Constants.AUDIO_ACTIVE_PREFS_KEY, audioActive);
        Agava.YandexGames.Utility.PlayerPrefs.Save();
#endif
    }
}