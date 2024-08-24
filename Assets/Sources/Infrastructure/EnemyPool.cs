using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    public EnemyPool(Enemy template) : base(template)
    {
    }

    public override Enemy GetObject()
    {
        if (_pool.TryDequeue(out Enemy item) == false)
        {
            Enemy newItem = Object.Instantiate(_template);
            newItem.gameObject.SetActive(false);
            newItem.SetPool(this);

            return newItem;
        }

        return item;
    }
}