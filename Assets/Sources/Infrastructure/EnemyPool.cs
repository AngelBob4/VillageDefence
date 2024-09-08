using System;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    public event Action WaveEnded;

    private int _requiredQuantity = 0;
    private int _releasedEnemies = 0;

    public EnemyPool(Enemy template) : base(template)
    {
    }

    public override Enemy GetObject()
    {
        if (_pool.TryDequeue(out Enemy item) == false)
        {
            Enemy newItem = UnityEngine.Object.Instantiate(_template);
            newItem.gameObject.SetActive(false);
            newItem.SetPool(this);

            return newItem;
        }

        return item;
    }

    public override void Release(IPoolable item)
    {
        _releasedEnemies++;

        if (_requiredQuantity == _releasedEnemies)
        {
            WaveEnded?.Invoke();
        }

        base.Release(item);
    }

    public void Reset(int requiredQuantity)
    {
        if (requiredQuantity >= 0)
        {
            _releasedEnemies = 0;
            _requiredQuantity = requiredQuantity;
        }
    }
}