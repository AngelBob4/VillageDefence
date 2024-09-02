using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private LeanLocalizedText _descriptionLocalization;
    [SerializeField] private Text _percentsOfEfficiencyLocalization;
    [SerializeField] private Image _image;

    private PlayerUpgrade _playerUpgrade;
    private Button _button;
    private Player _player;

    public void Init(Player player)
    {
        _player = player;
    }

    public void Reset(PlayerUpgrade playerUpgrade)
    {
        _playerUpgrade = playerUpgrade;
        _descriptionLocalization.TranslationName = _playerUpgrade.Description;
        _percentsOfEfficiencyLocalization.text = _playerUpgrade.Efficiency.ToString() + "%";
        _image.sprite = _playerUpgrade.Sprite;
    }

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _playerUpgrade.Upgrade(_player);
    }
}