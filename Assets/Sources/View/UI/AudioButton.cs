using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AudioButton : MonoBehaviour
{
    [SerializeField] private GameObject _audioOn;
    [SerializeField] private GameObject _audioOff;

    private Button _button;
    private GameAudio _gameAudio;

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleMusic);
    }

    public void Init(GameAudio gameAudio)
    {
        _gameAudio = gameAudio;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ToggleMusic);
    }

    private void ToggleMusic()
    {
        _gameAudio.ToggleMusic();
        _audioOn.SetActive(_gameAudio.MusicActive);
        _audioOff.SetActive(!_gameAudio.MusicActive);
    }
}