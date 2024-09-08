using UnityEngine;
using Agava.YandexGames;
using System;

public class VideoAdd : MonoBehaviour
{
    private Game _game;

    public void Init(Game game)
    {
        _game = game;
    }

    public void Show()
    {
#if !UNITY_EDITOR
        ShowVideo();
#endif
    }

    public void ShowVideo() =>
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardCallback, OnCloseCallback);

    public void OnOpenCallback()
    {
        _game.Pause();
    }

    public void OnCloseCallback()
    {
        _game.Resume();
    }

    private void OnRewardCallback()
    {
        //_addCoins
    }
}