using UnityEngine;
using UnityEngine.Audio;

public class GameAudio : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";

    [SerializeField] private AudioMixerGroup _audioMixer;
    [SerializeField] private AudioSource _musicAudioSource;

    private float _masterVolume;
    private float _minVolume = -80f;
    private float _maxVolume = 0f;
    private bool _musicActive = true;

    public bool MusicActive => _musicActive;

    public void ToggleMusic()
    {
        if (_musicActive)
        {
            _audioMixer.audioMixer.SetFloat(MasterVolume, _minVolume);
            _musicActive = false;
        }
        else
        {
            _audioMixer.audioMixer.SetFloat(MasterVolume, _masterVolume);
            _musicActive = true;
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        _masterVolume = Mathf.Lerp(_minVolume, _maxVolume, volume);
        _audioMixer.audioMixer.SetFloat(MasterVolume, _masterVolume);
    }
}