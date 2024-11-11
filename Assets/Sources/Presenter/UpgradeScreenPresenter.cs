using System.Collections.Generic;
using UnityEngine;
using YG;

public class UpgradeScreenPresenter : IPresenter
{
    private GameObject _advertisementLoadingPanel;
    private VideoAdvertisement _videoAdvertisement;
    private EnemyGenerator _enemyGenerator;
    private UpgradeScreenView _upgradeScreenView;
    private UpgradeScreen _upgradeScreen;
    private List<UpgradeButton> _upgradeButtons;

    public UpgradeScreenPresenter(UpgradeScreenView upgradeScreenView, UpgradeScreen upgradeScreen, List<UpgradeButton> upgradeButtons, 
        GameObject advertisementLoadingPanel, VideoAdvertisement videoAdvertisement, EnemyGenerator enemyGenerator)
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
            button.OnUpgrade += OnUpgrade;
        }
    }

    public void Disable()
    {
        YandexGame.CloseFullAdEvent -= OnCloseFullAdEvent;

        foreach (UpgradeButton button in _upgradeButtons)
        {
            button.OnUpgrade -= OnUpgrade;
        }
    }

    private void OnUpgrade(PlayerUpgrade upgrade)
    {
        _upgradeScreen.Upgrade(upgrade);

        if (_enemyGenerator.WaveCounter % 5 == 0)
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