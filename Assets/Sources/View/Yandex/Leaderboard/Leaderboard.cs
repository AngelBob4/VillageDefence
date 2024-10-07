using System;
using System.Collections.Generic;
using UnityEngine;
using YG;
using YG.Utils.LB;

public class Leaderboard : MonoBehaviour
{
    private AuthorizationOffer _authorizationOffer;
    private AuthorizationError _authorizationError;

    public event Action<LBThisPlayerData> ConstructPlayerInfo;
    public event Action<List<LBPlayerData>> ConstructEntries;

    public void Init(AuthorizationOffer authorizationOffer, AuthorizationError authorizationError)
    {
        _authorizationError = authorizationError;
        _authorizationOffer = authorizationOffer;
        YandexGame.GetLeaderboard(Constants.LEADERBOARD_NAME, 5, 5, 5, "nonePhoto");
    }

    private void OnEnable()
    {
        YandexGame.onGetLeaderboard += OnGetLeaderboard;
    }

    private void OnDisable()
    {
        YandexGame.onGetLeaderboard -= OnGetLeaderboard;
    }

    public void AuthorizationOfferOpen()
    {
        _authorizationOffer.Open();
    }

    private void OnGetLeaderboard(LBData lb)
    {
        if (lb.technoName == Constants.LEADERBOARD_NAME) 
        {
            ConstructPlayerInfo?.Invoke(lb.thisPlayer);
        }

        List<LBPlayerData> entries = new();

        foreach (LBPlayerData entry in lb.players)
            entries.Add(entry);

        ConstructEntries?.Invoke(entries);
    }
}