using UnityEngine;

public class PlayerCompositeRoot : CompositeRoot
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovementView _playerMovementView;
    [SerializeField] private AttackZoneView _attackZoneView;
    [SerializeField] private BackPackView _backPackView;
    [SerializeField] private LootZoneView _lootZoneView;
    [SerializeField] private Animator _animator;

    private PlayerMovement _playerMovement;
    private PlayerInputRouter _playerInputRouter;
    private Inventory _inventory;
    private AttackZone _attackZone;
    private Gun _gun;
    private PlayerAnimator _playerAnimator;

    public override void Compose()
    {
        _player.Init(100f);
        _inventory = new Inventory();
        _playerAnimator = new PlayerAnimator();

        _gun = new Gun(1f);
        _attackZone = new AttackZone(_gun, _playerAnimator, _inventory);

        _playerMovement = new PlayerMovement(5f, _attackZone, _player);
        _playerInputRouter = new PlayerInputRouter(_playerMovement);

        _playerMovementView.Init(_playerMovement);
        _attackZoneView.Init(_attackZone);
        _inventory.Init(_backPackView, _gun, 5);
        _lootZoneView.Init(_inventory);
        _backPackView.Init(0.3f);
        _playerAnimator.Init(_animator, _playerMovement);
    }

    private void Update()
    {
        _playerInputRouter.Update();
        _attackZone.Update();
        _playerAnimator.Update();
        _gun.Update(Time.deltaTime);
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