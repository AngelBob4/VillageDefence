using Agava.YandexGames;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _mainContainer;
    [SerializeField] private Transform _playerEntryContainer;
    [SerializeField] private Button _closeButton;
    [SerializeField] private LeaderboardEntryView _leaderboardEntryViewPrefab;

    private List<LeaderboardEntryView> _leaderboardEntryViewInstances = new();
    private LeaderboardEntryView _leaderboardPlayerViewInstance;

    private void Awake() => _closeButton.onClick.AddListener(Hide);
    private void OnDestroy() => _closeButton.onClick.RemoveListener(Hide);

    public void ConstructEntries(List<LeaderboardEntryData> entryDatas)
    {
        ClearEntries();
            
        foreach (LeaderboardEntryData entryData in entryDatas)
            _leaderboardEntryViewInstances.Add(CreateEntryView(entryData, _mainContainer));
    }

    public void ConstructPlayerInfo(LeaderboardEntryData entryData)
    {
        ClearPlayerEntry();
        _leaderboardPlayerViewInstance = CreateEntryView(entryData, _playerEntryContainer);
    }

    public void SetPlayerScore(int score)
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetEntries(Constants.LEADERBOARD_NAME, (result) =>
        {
            if (result == null || result.userRank < score)
                Agava.YandexGames.Leaderboard.SetScore(Constants.LEADERBOARD_NAME, score);
        });
    }

    public void Show() => gameObject.SetActive(true);
    private void Hide() => gameObject.SetActive(false);

    private LeaderboardEntryView CreateEntryView(LeaderboardEntryData entryData, Transform container)
    {
        LeaderboardEntryView entryView = Instantiate(_leaderboardEntryViewPrefab, container);
        entryView.Initialize(entryData);
            
        return entryView;
    }
        
    private void ClearEntries()
    {
        foreach (LeaderboardEntryView leaderboardEntryView in _leaderboardEntryViewInstances)
            Destroy(leaderboardEntryView.gameObject);

        _leaderboardEntryViewInstances.Clear();
    }

    private void ClearPlayerEntry()
    {
        if (_leaderboardPlayerViewInstance == null)
            return;
            
        Destroy(_leaderboardPlayerViewInstance.gameObject);
        _leaderboardPlayerViewInstance = null;
    }
}