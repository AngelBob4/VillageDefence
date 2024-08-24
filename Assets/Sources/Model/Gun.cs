using System;

public class Gun
{
    public event Action<Enemy> Shot;

    private float _currentReloadTime = 0;
    private float _reloadTime;
    private float _damage;

    public Gun(float reloadTime, float damage)
    {
        _reloadTime = reloadTime;
        _damage = damage;
    }

    public void Shoot(Enemy enemy)
    {
        if (ReadyToShoot())
        {
            Shot?.Invoke(enemy);
            _currentReloadTime = _reloadTime;
            enemy.GetDamage(_damage);
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

    private bool ReadyToShoot() => _currentReloadTime <= 0;
}