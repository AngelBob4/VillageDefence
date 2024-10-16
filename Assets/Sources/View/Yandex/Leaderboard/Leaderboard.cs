using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Agava.YandexGames;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Button _openButton;

    [SerializeField] private Game _game;
    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private AuthorizationOfferView _authorizationOfferView;
    [SerializeField] private AuthorizationErrorView _authorizationErrorView;

    private void Awake() => _openButton.onClick.AddListener(OnOpenButtonClick);
    private void OnDestroy() => _openButton.onClick.RemoveListener(OnOpenButtonClick);

    private void OpenLeaderboard()
    {
        Agava.YandexGames.Leaderboard.GetEntries(
            Constants.LEADERBOARD_NAME,
            result =>
            {
                List<LeaderboardEntryData> entries = new();

                foreach (Agava.YandexGames.LeaderboardEntryResponse entry in result.entries)
                    entries.Add(new LeaderboardEntryData(entry));

                _leaderboardView.ConstructEntries(entries);
            });

        Agava.YandexGames.Leaderboard.GetPlayerEntry(
            Constants.LEADERBOARD_NAME,
            entry => _leaderboardView.ConstructPlayerInfo(new LeaderboardEntryData(entry)));

        _leaderboardView.Show();
    }

    private void OnOpenButtonClick()
    {
        _game.Pause(_leaderboardView.gameObject);

        if (Agava.YandexGames.PlayerAccount.IsAuthorized)
        {
            OpenLeaderboard();
            return;
        }

        void onAuthorizeSuccess() =>
            Agava.YandexGames.Utility.PlayerPrefs.Load(
                () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));

        void onAuthorizeError() => _authorizationErrorView.Show();

        _authorizationOfferView.Show(onAuthorizeSuccess, onAuthorizeError);
    }

    private void OnAuthorizeError()
    {
        _game.Resume(_leaderboardView.gameObject);
        _authorizationErrorView.Show();
    }
}