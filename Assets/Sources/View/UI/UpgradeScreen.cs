using System.Collections.Generic;
using UnityEngine;

public class UpgradeScreen : Window
{
    [SerializeField] private List<UpgradeButton> _upgradeButtons;

    private List<PlayerUpgrade> _playerUpgrades = new List<PlayerUpgrade>();

    public void Init(Player player)
    {
        foreach (UpgradeButton button in _upgradeButtons)
        {
            button.Init(player);
        }

        //_playerUpgrades.Add();

        base.Init();
    }

    public override void Open()
    {
        foreach (UpgradeButton button in _upgradeButtons)
        {
            PlayerUpgrade randomUpgrade = _playerUpgrades[Random.Range(0, _playerUpgrades.Count)];
            button.Reset(randomUpgrade);
        }

        base.Open();
    }
}