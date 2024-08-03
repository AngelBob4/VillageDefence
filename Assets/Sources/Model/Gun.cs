using System;

public class Gun
{
    public event Action<Enemy> Shot;

    private float _currentReloadTime = 0;
    private float _reloadTime;

    private Inventory _inventory;

    public Gun(float reloadTime, Inventory inventory)
    {
        _reloadTime = reloadTime;
        _inventory = inventory;
    }

    public void Shoot(Enemy enemy)
    {
        if (ReadyToShoot())
        {
            Shot?.Invoke(enemy);
            _currentReloadTime = _reloadTime;
        }
    }

    public void Tick(float time)
    {
        if (_currentReloadTime < 0)
        {
            _currentReloadTime = 0;
        }
        else
        {
            _currentReloadTime -= time;
        }
    }

    private bool ReadyToShoot()
    {
        return _currentReloadTime <= 0 && _inventory.HasBullets;
    }
}