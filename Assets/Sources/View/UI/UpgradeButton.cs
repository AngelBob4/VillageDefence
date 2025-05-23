using System;
using Lean.Localization;
using Model.PlayerComponents.PlayerUpgrades;
using UnityEngine;
using UnityEngine.UI;
using View.PlayerComponents;

namespace View.UI
{
    [RequireComponent(typeof(Button))]
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField] private LeanLocalizedText _descriptionLocalization;
        [SerializeField] private Text _percentsOfEfficiencyLocalization;
        [SerializeField] private Image _image;
        [SerializeField] private Text _levelOfUpgrade;
        [SerializeField] private Button _button;

        private PlayerUpgrade _playerUpgrade;

        public event Action<PlayerUpgrade> Upgrading;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        public void Reset(PlayerUpgrade playerUpgrade, Player player)
        {
            _playerUpgrade = playerUpgrade;
            _descriptionLocalization.TranslationName = _playerUpgrade.Description;
            _percentsOfEfficiencyLocalization.text = _playerUpgrade.Efficiency.ToString() + "%";
            _image.sprite = _playerUpgrade.Sprite;
            _levelOfUpgrade.text = player.StatLevel(_playerUpgrade.Stat).ToString();
        }

        private void OnButtonClick()
        {
            Upgrading?.Invoke(_playerUpgrade);
        }
    }
}