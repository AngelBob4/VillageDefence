using UnityEngine;

public class Player : Unit
{
    [SerializeField] private PlayerMovementView _playerMovementView;
    [SerializeField] private AttackZoneView _attackZoneView;
    [SerializeField] private BackPackView _backPackView;
    [SerializeField] private LootZoneView _lootZoneView;
    [SerializeField] private Animator _animator;
    [SerializeField] private Particle _shootParticle;
    [SerializeField] private Transform _gunParticleTransform;
    [SerializeField] private TrailRenderer _shootingTrail;
    [SerializeField] private UnitHelathBar _healthBar;
    [SerializeField] private Transform _body;

    private Gun _gun;
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

    public Gun Gun => _gun;
    public PlayerInputRouter PlayerInputRouter => _playerInputRouter;
    public AttackZone AttackZone => _attackZone;
    public PlayerAnimator PlayerAnimator => _playerAnimator;

    public void Init()
    {
        this.Init(_maxHealth, _healthBar);
        _inventory = new Inventory();
        _playerAnimator = new PlayerAnimator();
        _gun = new Gun(_gunReloadTime, _gunDamage);
        _gunParticles = new GunParticles(_shootParticle, _gun, _gunParticleTransform, _shootingTrail);
        _attackZone = new AttackZone(_gun, _playerAnimator, _inventory);

        _playerMovement = new PlayerMovement(_movementSpeed, _attackZone, this);
        _playerInputRouter = new PlayerInputRouter(_playerMovement);

        _playerMovementView.Init(_playerMovement, _body);
        _attackZoneView.Init(_attackZone);
        _inventory.Init(_backPackView, _gun, _inventoryMaxBullets);
        _lootZoneView.Init(_inventory);
        _backPackView.Init(_backpackBulletsOffset);
        _playerAnimator.Init(_animator, _playerMovement);

        OnDeath += Death;
        base.Init(_maxHealth, _healthBar);
    }

    private void OnEnable()
    {
        _playerInputRouter.OnEnable();
    }

    private void OnDisable()
    {
        _playerInputRouter.OnDisable();
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }

    public void UpgradePlayer()
    {
        Death();
    }
}