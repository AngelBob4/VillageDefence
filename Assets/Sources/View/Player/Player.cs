using UnityEngine;
using System.Collections.Generic;

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
    [SerializeField] private AudioSource _shoot;
    [SerializeField] private Game _game;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Particle _hitParticle;
    [SerializeField] private AudioSource _hitAudio;

    private Gun _gun;
    private PlayerMovement _playerMovement;
    private PlayerInputRouter _playerInputRouter;
    private Inventory _inventory;
    private AttackZone _attackZone;
    private PlayerAnimator _playerAnimator;
    private GunParticles _gunParticles;
    private Dictionary<PlayerStats, int> _playerStats;

    private float _playerMaxHealth = 100f;
    private float _gunReloadTime = 1f;
    private float _gunDamage = 10f;
    private float _movementSpeed = 5f;
    private int _inventoryMaxBullets = 5;
    private float _backpackBulletsOffset = 0.3f; 
    private float _regeneration = 0; 

    public Gun Gun => _gun;
    public PlayerInputRouter PlayerInputRouter => _playerInputRouter;
    public AttackZone AttackZone => _attackZone;
    public PlayerAnimator PlayerAnimator => _playerAnimator;

    private void OnEnable()
    {
        _playerInputRouter.OnEnable();
    }

    private void OnDisable()
    {
        _playerInputRouter.OnDisable();
    }

    public void Init()
    {
        new PlayerParticles(this, _hitParticle, _hitAudio);
        _inventory = new Inventory();
        _playerAnimator = new PlayerAnimator();
        _gun = new Gun(_gunReloadTime, _gunDamage, this, _shoot);
        _gunParticles = new GunParticles(_shootParticle, _gun, _gunParticleTransform, _shootingTrail);
        _attackZone = new AttackZone(_gun, _playerAnimator, _inventory);
        _playerStats = new Dictionary<PlayerStats, int>()
        {
            {PlayerStats.Damage, 0 },
            {PlayerStats.Heal, 0 },
            {PlayerStats.Lifesteal, 0 },
        };

        _playerMovement = new PlayerMovement(_movementSpeed, _attackZone, this);
        _playerInputRouter = new PlayerInputRouter(_playerMovement, _joystick);

        _playerMovementView.Init(_playerMovement, _body);
        _attackZoneView.Init(_attackZone);
        _inventory.Init(_backPackView, _gun, _inventoryMaxBullets);
        _lootZoneView.Init(_inventory);
        _backPackView.Init(_backpackBulletsOffset);
        _playerAnimator.Init(_animator, _playerMovement);

        OnDeath += Death;
        base.Init(_playerMaxHealth, _healthBar);
    }

    public void Tick(float time)
    {
        Heal(_regeneration * time);
    }

    public void Upgrade(UpgradeDamage upgrade)
    {
        _gun.AppendDamage(upgrade.Efficiency);
    }

    public void Upgrade(UpgradeLifesteal upgrade)
    {
        _gun.AppendLifesteal(upgrade.Efficiency);
    }

    public void Upgrade(UpgradeRegeneration upgrade)
    {
        if (upgrade.Efficiency >= 0)
            _regeneration += upgrade.Efficiency;
    }

    private void Death()
    {
        _game.OnGameOver();
    }
}