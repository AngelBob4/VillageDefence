using System;

public class Inventory
{
    public bool HasBullets => _bullets > 0;
    
    private bool MaxBullets => _bullets == _maxBullets;

    private BackPackView _backPackView;
    private Gun _gun;

    private int _maxBullets;
    private int _bullets = 0;

    public event Action BulletPickedUp;

    public void Init(BackPackView backPackView, Gun gun, int maxBullets)
    {
        _backPackView = backPackView;
        _gun = gun;
        _maxBullets = maxBullets;

        _gun.Shot += OnShoot;
    }

    public void AddBullet(Bullet bullet)
    {
        if (MaxBullets == false)
        {
            _bullets++;
            _backPackView.AddBullet(bullet);
            BulletPickedUp?.Invoke();
        }
    }

    public void OnShoot(Enemy enemy)
    {
        _bullets--;
        _backPackView.RemoveBullet();
    }
}