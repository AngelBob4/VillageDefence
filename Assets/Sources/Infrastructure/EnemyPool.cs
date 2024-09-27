using System;

public class EnemyPool : ObjectPool<Enemy>
{
    public event Action EnemyReturned;

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
        EnemyReturned?.Invoke();

        base.Release(item);
    }
}