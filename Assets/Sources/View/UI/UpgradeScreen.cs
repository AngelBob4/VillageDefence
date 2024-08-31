using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeScreen : Window
{
    [SerializeField] private List<UpgradeButton> _upgradeButtons;
    [SerializeField] private Image _upgradeDamage;

    private List<PlayerUpgrade> _playerUpgrades = new List<PlayerUpgrade>();

    public void Init(Player player)
    {
        foreach (UpgradeButton button in _upgradeButtons)
        {
            button.Init(player);
        }

        CreateUpgrades();
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

    private void CreateUpgrades()
    {
        UpgradeDamage upgradeDamage = new UpgradeDamage(_upgradeDamage);
        _playerUpgrades.Add(upgradeDamage);
    }
}