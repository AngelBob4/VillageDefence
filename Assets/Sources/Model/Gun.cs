using System;

public class Gun
{
    public event Action<Enemy> Shoot;

    private float _currentReloadTime = 0;

    private float _reloadTime;

    private Inventory _inventory;

    public Gun(float reloadTime, Inventory inventory)
    {
        _reloadTime = reloadTime;
        _inventory = inventory;
    }

    public void TryToShoot(Enemy enemy)
    {
        if (ReadyToShoot())
        {
            Shoot.Invoke(enemy);
        }
    }

    public void Tick(float time)
    {
        _currentReloadTime -= time;
    }

    private bool ReadyToShoot()
    {
        return _currentReloadTime == 0 && _inventory.HasBullets;
    }
}