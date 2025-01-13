using Infrastructure;
using Model;
using System.Collections.Generic;
using View.Yandex;
using View.Yandex.Leaderboard;
using YG;
using YG.Utils.LB;

namespace Presenter
{
    public class LeaderboardPresenter : IPresenter
    {
        private PauseService _pauseService;
        private LeaderboardView _view;
        private Leaderboard _model;

        public LeaderboardPresenter(PauseService pauseService, LeaderboardView leaderboardView,
            Leaderboard leaderboard)
        {
            _pauseService = pauseService;
            _view = leaderboardView;
            _model = leaderboard;
        }

        public void Enable()
        {
            _view.OpenButtonClicked += OnOpenButtonClicked;
            _view.ExitButtonClicked += OnExitButtonClicked;
            _view.AuthorizationOfferOpen += OnAuthorizationOfferOpen;
            _model.ConstructEntries += OnConstructEntries;
            _model.ConstructPlayerInfo += OnConstructPlayerInfo;
        }

        public void Disable()
        {
            _view.OpenButtonClicked -= OnOpenButtonClicked;
            _view.ExitButtonClicked -= OnExitButtonClicked;
            _view.AuthorizationOfferOpen -= OnAuthorizationOfferOpen;
            _model.ConstructEntries -= OnConstructEntries;
            _model.ConstructPlayerInfo -= OnConstructPlayerInfo;
        }

        private void OnOpenButtonClicked()
        {
            int maxQuantityPlayers = 5;
            int quantityTop = 5;
            int quantityAround = 5;

            _pauseService.Pause(_view.gameObject);
            YandexGame.GetLeaderboard(Constants.LeaderboardName,
                maxQuantityPlayers,
                quantityTop,
                quantityAround,
                "nonePhoto");
        }

        private void OnExitButtonClicked()
        {
            _pauseService.Unpause(_view.gameObject);
        }

        private void OnAuthorizationOfferOpen()
        {
            _model.AuthorizationOfferOpen();
        }

        private void OnConstructPlayerInfo(LBThisPlayerData entryData)
        {
            _view.ConstructPlayerInfo(entryData);
        }

        private void OnConstructEntries(List<LBPlayerData> entryDatas)
        {
            _view.ConstructEntries(entryDatas);
        }
    }
}