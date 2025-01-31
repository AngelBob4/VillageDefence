using System;
using System.Collections.Generic;
using Infrastructure;
using InputSystem;
using Model;
using Model.PlayerComponents;
using Model.PlayerComponents.PlayerUpgrades;
using Presenter;
using UnityEngine;

namespace View.PlayerComponents
{
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
        [SerializeField] private AudioSource _bulletPickUp;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Particle _hitParticle;
        [SerializeField] private AudioSource _hitAudio;
        [SerializeField] private GunView _gunView;

        private Gun _gun;
        private PlayerMovement _playerMovement;
        private PlayerInputRouter _playerInputRouter;
        private Inventory _inventory;
        private AttackZone _attackZone;
        private PlayerAnimator _playerAnimator;
        private GunParticles _gunParticles;
        private Dictionary<PlayerStats, int> _playerStats;
        private IPresenter _presenter;

        private float _playerMaxHealth = 100f;
        private float _gunReloadTime = 1f;
        private float _gunDamage = 10f;
        private float _movementSpeed = 5f;
        private int _inventoryMaxBullets = 5;
        private float _backpackBulletsOffset = 0.3f;
        private float _regeneration = 0;

        public event Action Died;
        public event Action Revived;

        public Gun Gun => _gun;
        public PlayerInputRouter PlayerInputRouter => _playerInputRouter;
        public AttackZone AttackZone => _attackZone;
        public PlayerAnimator PlayerAnimator => _playerAnimator;

        private void OnEnable()
        {
            _presenter?.Enable();
            _playerInputRouter.OnEnable();
        }

        private void OnDisable()
        {
            _presenter?.Disable();
            _playerInputRouter.OnDisable();
        }

        public void Init(IPresenter presenter)
        {
            _presenter = presenter;
            _presenter?.Enable();
            
            new PlayerParticles(this, _hitParticle, _hitAudio);
            _inventory = new Inventory();
            _playerAnimator = new PlayerAnimator();
            _gun = new Gun(_gunReloadTime, _gunDamage, this, _shoot, _bulletPickUp);
            _gunParticles = new GunParticles(_shootParticle, _gun, _gunParticleTransform, _shootingTrail);
            _attackZone = new AttackZone(_gun, _playerAnimator, _inventory);
            _playerStats = new Dictionary<PlayerStats, int>()
            {
                { PlayerStats.Damage, 0 },
                { PlayerStats.Regeneration, 0 },
                { PlayerStats.Lifesteal, 0 },
            };

            _playerMovement = new PlayerMovement(_movementSpeed, _attackZone, this);
            _playerInputRouter = new PlayerInputRouter(_playerMovement, _joystick);
            GunPresenter gunPresenter = new GunPresenter(_inventory, _gun);

            _gunView.Init(gunPresenter);
            _playerMovementView.Init(_playerMovement, _body);
            _attackZoneView.Init(_attackZone);
            _inventory.Init(_backPackView, _gun, _inventoryMaxBullets);
            _lootZoneView.Init(_inventory);
            _backPackView.Init(_backpackBulletsOffset);
            _playerAnimator.Init(_animator, _playerMovement);

            Dying += Die;
            Init(_playerMaxHealth, _healthBar);
        }

        public int StatLevel(PlayerStats stat) => _playerStats[stat];

        public void Tick(float time)
        {
            Heal(_regeneration * time);
        }

        public void Upgrade(UpgradeDamage upgrade)
        {
            _playerStats[upgrade.Stat]++;
            _gun.AppendDamage(upgrade.Efficiency);
        }

        public void Upgrade(UpgradeLifesteal upgrade)
        {
            _playerStats[upgrade.Stat]++;
            _gun.AppendLifesteal(upgrade.Efficiency);
        }

        public void Upgrade(UpgradeRegeneration upgrade)
        {
            _playerStats[upgrade.Stat]++;
            if (upgrade.Efficiency >= 0)
                _regeneration += upgrade.Efficiency;
        }

        public void Revive()
        {
            Init(_playerMaxHealth, _healthBar);
            Revived?.Invoke();
        }

        private void Die()
        {
            Died?.Invoke();
        }
    }
}