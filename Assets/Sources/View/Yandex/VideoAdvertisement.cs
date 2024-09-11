using UnityEngine;
using Agava.YandexGames;

public class VideoAdvertisement : MonoBehaviour
{
    private Game _game;

    public void Init(Game game)
    {
        _game = game;
    }

    public void ShowVideo() =>
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, OnRewardCallback, OnCloseCallback);

    public void ShowInterstitial() =>
        InterstitialAd.Show(OnOpenCallback, OnCloseCallback);


    public void OnOpenCallback()
    {
        _game.Pause();
    }

    public void OnCloseCallback()
    {
        _game.Resume();
    }

    public void OnCloseCallback(bool onClose)
    {
        _game.Resume();
    }

    private void OnRewardCallback()
    {
        //_addCoins
    }
}