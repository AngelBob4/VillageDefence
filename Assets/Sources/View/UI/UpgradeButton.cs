using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Text _description;
    [SerializeField] private Text _percentsOfEfficiency;

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
        _description.text = _playerUpgrade.Description;
        _percentsOfEfficiency.text = _playerUpgrade.PercentsOfEfficiency;
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