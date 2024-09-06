using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AudioButton : MonoBehaviour
{
    [SerializeField] private GameObject _audioOn;
    [SerializeField] private GameObject _audioOff;

    private Button _button;
    private Game _game;

    public void Init(Game game)
    {
        _button = GetComponent<Button>();
        _game = game;
    }

    private void AudioOn()
    {
        _audioOn.SetActive(true);
        _audioOff.SetActive(false);
    }

    private void AudioOff()
    {
        _audioOn.SetActive(false);
        _audioOff.SetActive(true);
    }
}