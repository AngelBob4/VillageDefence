using UnityEngine;
using Agava.WebUtility;
using System;

public class CheckingFocus : MonoBehaviour
{
    [SerializeField] private Game _game;

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        PauseGame(!inApp); 
    }

    private void OnInBackgroundChangeWeb(bool isBackground) 
    {
        PauseGame(isBackground);
    }

    private void PauseGame(bool value) 
    {
        if (value)
            _game.Pause(gameObject);
        else
            _game.Resume(gameObject);
    }
}