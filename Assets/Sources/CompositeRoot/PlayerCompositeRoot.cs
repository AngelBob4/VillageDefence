using UnityEngine;

public class PlayerCompositeRoot : CompositeRoot
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMovementView _playerMovementView;
    [SerializeField] private AttackZoneView _attackZoneView;
    [SerializeField] private BackPackView _backPackView;
    [SerializeField] private LootZoneView _lootZoneView;
    [SerializeField] private Animator _animator;
    [SerializeField] private Gun _gun;
    [SerializeField] private Particle _shootParticle;
    [SerializeField] private Transform _gunParticleTransform;
    [SerializeField] private TrailRenderer _shootingTrail;

    private PlayerMovement _playerMovement;
    private PlayerInputRouter _playerInputRouter;
    private Inventory _inventory;
    private AttackZone _attackZone;
    private PlayerAnimator _playerAnimator;
    private GunParticles _gunParticles;

    private float _maxHealth = 100f;
    private float _gunReloadTime = 1f;
    private float _gunDamage = 10f;
    private float _movementSpeed = 5f;
    private int _inventoryMaxBullets = 5;
    private float _backpackBulletsOffset = 0.3f;

    public override void Compose()
    {
        _player.Init(_maxHealth);
        _inventory = new Inventory();
        _playerAnimator = new PlayerAnimator();
        _gun = new Gun(_gunReloadTime, _gunDamage);

        _gunParticles = new GunParticles(_shootParticle, _gun, _gunParticleTransform, _shootingTrail);
        _attackZone = new AttackZone(_gun, _playerAnimator, _inventory);

        _playerMovement = new PlayerMovement(_movementSpeed, _attackZone, _player);
        _playerInputRouter = new PlayerInputRouter(_playerMovement);

        _playerMovementView.Init(_playerMovement);
        _attackZoneView.Init(_attackZone);
        _inventory.Init(_backPackView, _gun, _inventoryMaxBullets);
        _lootZoneView.Init(_inventory);
        _backPackView.Init(_backpackBulletsOffset);
        _playerAnimator.Init(_animator, _playerMovement);
    }

    private void Update()
    {
        _playerInputRouter.Update();
        _attackZone.Update();
        _playerAnimator.Update();
        _gun.Tick(Time.deltaTime);
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