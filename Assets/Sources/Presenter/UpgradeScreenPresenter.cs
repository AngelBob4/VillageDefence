using Infrastructure;
using Model;
using Model.EnemyComponents;
using Model.PlayerComponents.PlayerUpgrades;
using System.Collections.Generic;
using UnityEngine;
using View.UI;
using View.Yandex;
using YG;

namespace Presenter
{
    public class UpgradeScreenPresenter : IPresenter
    {
        private GameObject _advertisementLoadingPanel;
        private VideoAdvertisement _videoAdvertisement;
        private EnemyGenerator _enemyGenerator;
        private UpgradeScreenView _upgradeScreenView;
        private UpgradeScreen _upgradeScreen;
        private List<UpgradeButton> _upgradeButtons;

        public UpgradeScreenPresenter(
            UpgradeScreenView upgradeScreenView,
            UpgradeScreen upgradeScreen,
            List<UpgradeButton> upgradeButtons,
            GameObject advertisementLoadingPanel,
            VideoAdvertisement videoAdvertisement,
            EnemyGenerator enemyGenerator)
        {
            _upgradeScreenView = upgradeScreenView;
            _upgradeScreen = upgradeScreen;
            _upgradeButtons = upgradeButtons;
            _advertisementLoadingPanel = advertisementLoadingPanel;
            _videoAdvertisement = videoAdvertisement;
            _enemyGenerator = enemyGenerator;
        }

        public void Enable()
        {
            YandexGame.CloseFullAdEvent += OnCloseFullAdEvent;
            _upgradeScreenView.Close();

            foreach (UpgradeButton button in _upgradeButtons)
            {
                button.Upgrading += OnUpgrade;
            }
        }

        public void Disable()
        {
            YandexGame.CloseFullAdEvent -= OnCloseFullAdEvent;

            foreach (UpgradeButton button in _upgradeButtons)
            {
                button.Upgrading -= OnUpgrade;
            }
        }

        private void OnUpgrade(PlayerUpgrade upgrade)
        {
            int advertisementInterval = 5;

            _upgradeScreen.Upgrade(upgrade);

            if (_enemyGenerator.WaveCounter % advertisementInterval == 0)
            {
                _advertisementLoadingPanel.SetActive(true);
                _videoAdvertisement.ShowInterstitial();
            }
            else
            {
                _upgradeScreen.Close();
            }
        }

        private void OnCloseFullAdEvent()
        {
            _advertisementLoadingPanel.SetActive(false);
            _upgradeScreen.Close();
        }
    }
}