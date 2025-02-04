using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Model.PlayerComponents.PlayerUpgrades;
using UnityEngine;
using View.PlayerComponents;
using View.UI;

namespace Model
{
    public class UpgradeScreen
    {
        private PauseService _pauseService;
        private Player _player;
        private Sprite _upgradeDamage;
        private Sprite _upgradeRegeneration;
        private Sprite _upgradeLifesteal;

        private CancellationToken _cancellationToken;

        private UpgradeScreenView _upgradeScreenView;
        private List<UpgradeButton> _upgradeButtons;
        private List<PlayerUpgrade> _playerUpgrades = new List<PlayerUpgrade>();

        public UpgradeScreen(
            PauseService pauseService,
            Player player, Sprite upgradeDamage,
            Sprite upgradeRegeneration,
            Sprite upgradeLifesteal,
            UpgradeScreenView upgradeScreenView,
            List<UpgradeButton> upgradeButtons)
        {
            _pauseService = pauseService;
            _player = player;
            _upgradeDamage = upgradeDamage;
            _upgradeRegeneration = upgradeRegeneration;
            _upgradeLifesteal = upgradeLifesteal;
            _upgradeScreenView = upgradeScreenView;
            _upgradeButtons = upgradeButtons;
            _cancellationToken = _upgradeScreenView.gameObject.GetCancellationTokenOnDestroy();

            CreateUpgrades();
        }

        public async void Open(float openingDelay)
        {
            try
            {
                var shuffledcards = _playerUpgrades.OrderBy(_ => Guid.NewGuid()).ToList();

                for (int i = 0; i < _upgradeButtons.Count; i++)
                {
                    _upgradeButtons[i].Reset(shuffledcards[i], _player);
                }

                _upgradeScreenView.Open(openingDelay);
                await UniTask.Delay(TimeSpan.FromSeconds(openingDelay), ignoreTimeScale: false,
                    cancellationToken: _cancellationToken);
                _pauseService.Pause(_upgradeScreenView.gameObject);
            }
            catch (OperationCanceledException _)
            {
            }
        }

        public void Close()
        {
            _upgradeScreenView.Close();
            _pauseService.Unpause(_upgradeScreenView.gameObject);
        }

        public void Upgrade(PlayerUpgrade upgrade)
        {
            upgrade.Upgrade(_player);
        }

        private void CreateUpgrades()
        {
            UpgradeDamage upgradeDamage = new UpgradeDamage(_upgradeDamage);
            UpgradeLifesteal upgradeLifesteal = new UpgradeLifesteal(_upgradeLifesteal);
            UpgradeRegeneration upgradeRegeneration = new UpgradeRegeneration(_upgradeRegeneration);
            _playerUpgrades = new List<PlayerUpgrade>() { upgradeDamage, upgradeLifesteal, upgradeRegeneration };
        }
    }
}