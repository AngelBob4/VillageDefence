using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreenPresenter : IPresenter
{
    private UpgradeScreenView _upgradeScreenView;
    private UpgradeScreen _upgradeScreen;
    private List<UpgradeButton> _upgradeButtons;

    public UpgradeScreenPresenter(UpgradeScreenView upgradeScreenView, UpgradeScreen upgradeScreen, List<UpgradeButton> upgradeButtons)
    {
        _upgradeScreenView = upgradeScreenView;
        _upgradeScreen = upgradeScreen;
        _upgradeButtons = upgradeButtons;
    }

    public void Enable()
    {
        _upgradeScreenView.Close();

        foreach (UpgradeButton button in _upgradeButtons)
        {
            button.OnUpgrade += OnUpgrade;
        }
    }

    public void Disable()
    {
        foreach (UpgradeButton button in _upgradeButtons)
        {
            button.OnUpgrade -= OnUpgrade;
        }
    }

    private void OnUpgrade(PlayerUpgrade upgrade)
    {
        _upgradeScreen.Upgrade(upgrade);
        _upgradeScreen.Close();
    }
}