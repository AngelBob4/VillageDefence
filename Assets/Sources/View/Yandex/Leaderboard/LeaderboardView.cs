using YG;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG.Utils.LB;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    [SerializeField] private Transform _mainContainer;
    [SerializeField] private Transform _resultsContainer;
    [SerializeField] private Transform _playerEntryContainer;
    [SerializeField] private LeaderboardEntryView _leaderboardEntryViewPrefab;

    private List<LeaderboardEntryView> _leaderboardEntryViewInstances = new();
    private LeaderboardEntryView _leaderboardPlayerViewInstance;
    private LBThisPlayerData _lBThisPlayerData;
    private IPresenter _presenter;

    public event Action OpenButtonClicked;
    public event Action ExitButtonClicked;
    public event Action AuthorizationOfferOpen;

    public void Init(IPresenter presenter)
    {
        gameObject.SetActive(false);
        _presenter = presenter;
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(Hide);
        _openButton.onClick.AddListener(Show);
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(Hide);
        _openButton.onClick.RemoveListener(Show);
        _presenter.Disable();
    }

    public void ConstructEntries(List<LBPlayerData> entryDatas)
    {
        ClearEntries();

        foreach (LBPlayerData entryData in entryDatas)
            _leaderboardEntryViewInstances.Add(CreateEntryView(entryData, _resultsContainer));
    }

    public void ConstructPlayerInfo(LBThisPlayerData entryData)
    {
        ClearPlayerEntry();
        _leaderboardPlayerViewInstance = CreateEntryView(entryData, _playerEntryContainer);
        _lBThisPlayerData = entryData;
    }

    public void SetPlayerScore(int score)
    {
        if (YandexGame.auth == false)
            return;

        if (_lBThisPlayerData.score < score)
            YandexGame.NewLeaderboardScores(Constants.LEADERBOARD_NAME, score);
    }

    private void Show()
    {
        if (YandexGame.auth)
        {
            _mainContainer.gameObject.SetActive(true);
            OpenButtonClicked?.Invoke();
        }
        else
        {
            AuthorizationOfferOpen?.Invoke();
        }
    }

    private void Hide()
    {
        _mainContainer.gameObject.SetActive(false);
        ExitButtonClicked?.Invoke();
    }

    private LeaderboardEntryView CreateEntryView(LBPlayerData entryData, Transform container)
    {
        LeaderboardEntryView entryView = Instantiate(_leaderboardEntryViewPrefab, container);
        entryView.Initialize(entryData);
            
        return entryView;
    }

    private LeaderboardEntryView CreateEntryView(LBThisPlayerData entryData, Transform container)
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