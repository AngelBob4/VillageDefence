using UnityEngine;

public class PlayerCompositeRoot : CompositeRoot
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraCompositeRoot _cameraCompositeRoot;

    [SerializeField] private PlayerMovementView _playerMovementView;
    [SerializeField] private AttackZoneView _attackZoneView;
    [SerializeField] private BackPackView _backPackView;
    [SerializeField] private LootZoneView _lootZoneView;

    private PlayerMovement _playerMovement;
    private PlayerInputRouter _playerInputRouter;
    private Inventory _inventory;
    private AttackZone _attackZone;
    private Gun _gun;

    public override void Compose()
    {
        _player.PlayerInit(100f);
        _inventory = new Inventory();

        _gun = new Gun(1f, _inventory);
        _attackZone = new AttackZone(_gun);

        _playerMovement = new PlayerMovement(5f, _attackZone, _player);
        _playerInputRouter = new PlayerInputRouter(_playerMovement);

        _playerMovementView.Init(_playerMovement);
        _attackZoneView.Init(_attackZone);
        _inventory.Init(_backPackView, _gun, 5);
        _lootZoneView.Init(_inventory);
        _cameraCompositeRoot.Init(_player);
        _backPackView.Init(0.3f);
    }

    private void Update()
    {
        _playerInputRouter.Update();
        _gun.Tick(Time.deltaTime);
        _attackZone.Update();
    }

    private void OnEnable()
    {
        _playerInputRouter.OnEnable();
    }

    private void OnDisable()
    {
        _playerInputRouter.OnDisable();
    }
}