using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private LeanLocalizedText _descriptionLocalization;
    [SerializeField] private Text _percentsOfEfficiencyLocalization;
    [SerializeField] private Image _image;
    [SerializeField] private Text _levelOfUpgrade;

    private PlayerUpgrade _playerUpgrade;
    private Game _game;
    private Button _button;
    private Player _player;
    private UpgradeScreen _upgradeScreen;

    public void Init(Game game, Player player, UpgradeScreen upgradeScreen)
    {
        _game = game;
        _player = player;
        _upgradeScreen = upgradeScreen;
    }

    public void Reset(PlayerUpgrade playerUpgrade)
    {
        _playerUpgrade = playerUpgrade;
        _descriptionLocalization.TranslationName = _playerUpgrade.Description;
        _percentsOfEfficiencyLocalization.text = _playerUpgrade.Efficiency.ToString() + "%";
        _image.sprite = _playerUpgrade.Sprite;
        _levelOfUpgrade.text = _player.StatLevel(_playerUpgrade.Stat).ToString();
    }

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _game.Resume(_upgradeScreen.gameObject);
        _playerUpgrade.Upgrade(_player);
        _upgradeScreen.Close();
    }
}