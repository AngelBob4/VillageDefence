using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class UpgradeScreen : Window
{
    [SerializeField] private List<UpgradeButton> _upgradeButtons;
    [SerializeField] private Sprite _upgradeDamage;
    [SerializeField] private Sprite _upgradeRegeneration;
    [SerializeField] private Sprite _upgradeLifesteal;
    [SerializeField] private Game _game;

    private List<PlayerUpgrade> _playerUpgrades = new List<PlayerUpgrade>();

    public void Init(Player player)
    {
        foreach (UpgradeButton button in _upgradeButtons)
        {
            button.Init(_game, player, this);
        }

        CreateUpgrades();
        base.Init();
    }

    public override void Open()
    {
        _game.Pause(gameObject); 
        var shuffledcards = _playerUpgrades.OrderBy(_ => Guid.NewGuid()).ToList();

        for (int i = 0; i < _upgradeButtons.Count; i++)
        {
            _upgradeButtons[i].Reset(shuffledcards[i]);
        }

        base.Open();
    }

    private void CreateUpgrades()
    {
        UpgradeDamage upgradeDamage = new UpgradeDamage(_upgradeDamage);
        UpgradeLifesteal upgradeLifesteal = new UpgradeLifesteal(_upgradeLifesteal);
        UpgradeRegeneration upgradeRegeneration = new UpgradeRegeneration(_upgradeRegeneration);
        _playerUpgrades = new List<PlayerUpgrade>() { upgradeDamage, upgradeLifesteal, upgradeRegeneration };
    }
}