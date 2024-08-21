using System;

public class Gun
{
    public event Action<Enemy> Shot;

    private float _currentReloadTime = 0;
    private float _reloadTime;

    public Gun(float reloadTime)
    {
        _reloadTime = reloadTime;
    }

    public void Shoot(Enemy enemy)
    {
        if (ReadyToShoot())
        {
            Shot?.Invoke(enemy);
            _currentReloadTime = _reloadTime;
        }
    }

    public void Update(float time)
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