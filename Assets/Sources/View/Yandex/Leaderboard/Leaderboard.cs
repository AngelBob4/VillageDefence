using Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using YG;
using YG.Utils.LB;

namespace View.Yandex.Leaderboard
{
    public class Leaderboard : MonoBehaviour
    {
        private AuthorizationOffer _authorizationOffer;
        private AuthorizationError _authorizationError;

        public event Action<LBThisPlayerData> ConstructPlayerInfo;
        public event Action<List<LBPlayerData>> ConstructEntries;

        public void Init(AuthorizationOffer authorizationOffer, AuthorizationError authorizationError)
        {
            int maxQuantityPlayers = 5;
            int quantityTop = 5;
            int quantityAround = 5;

            _authorizationError = authorizationError;
            _authorizationOffer = authorizationOffer;
            YandexGame.GetLeaderboard(Constants.LeaderboardName,
                maxQuantityPlayers,
                quantityTop,
                quantityAround,
                "nonePhoto");
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
            if (lb.technoName != Constants.LeaderboardName)
            {
                return;
            }

            ConstructPlayerInfo?.Invoke(lb.thisPlayer);
            List<LBPlayerData> entries = new();

            foreach (LBPlayerData entry in lb.players)
                entries.Add(entry);

            ConstructEntries?.Invoke(entries);
        }
    }
}