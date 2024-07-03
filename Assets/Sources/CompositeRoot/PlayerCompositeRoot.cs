using UnityEngine;

public class PlayerCompositeRoot : CompositeRoot
{
    [SerializeField] private PlayerMovementView _playerMovementView;
    [SerializeField] private AttackZoneView _attackZoneView;
    [SerializeField] private CameraCompositeRoot _cameraCompositeRoot;
    [SerializeField] private Player _player;

    private PlayerMovement _playerMovement;
    private Inventory _inventory;
    private PlayerInputRouter _playerInputRouter;
    private AttackZone _attackZone;

    private Gun _gun;

    public override void Compose()
    {
        _player.PlayerInit(100f);
        _inventory = new Inventory();

        _gun = new Gun(2f, _inventory);
        _attackZone = new AttackZone(_gun);

        _playerMovement = new PlayerMovement(5f, _attackZone, _player);
        _playerInputRouter = new PlayerInputRouter(_playerMovement);

        _playerMovementView.Init(_playerMovement);
        _attackZoneView.Init(_attackZone);

        _cameraCompositeRoot.Init(_player);
    }

    private void Update()
    {
        _playerInputRouter.Update();
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