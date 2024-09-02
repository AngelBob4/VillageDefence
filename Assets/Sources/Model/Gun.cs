using System;

public class Gun 
{
    public event Action<Enemy> Shot;

    private float _currentReloadTime = 0;
    private float _reloadTime;
    private float _damage;
    private float _percentOfLifesteal = 0;
    private Player _player;

    private float Lifesteal => _damage * _percentOfLifesteal / 100;

    public Gun(float reloadTime, float damage, Player player)
    {
        _reloadTime = reloadTime;
        _damage = damage;
        _player = player;
    }

    public void Shoot(Enemy enemy)
    {
        if (ReadyToShoot())
        {
            Shot?.Invoke(enemy);
            _currentReloadTime = _reloadTime;
            enemy.GetDamage(_damage);
            _player.Heal(Lifesteal);
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

    public void AppendDamage(float percentOfDamage)
    {
        if (percentOfDamage >= 0)
            _damage += _damage * percentOfDamage / 100;
    }

    public void AppendLifesteal(float percentOfLifesteal)
    {
        if (percentOfLifesteal >= 0)
            _percentOfLifesteal += percentOfLifesteal;
    }

    private bool ReadyToShoot() => _currentReloadTime <= 0;
}