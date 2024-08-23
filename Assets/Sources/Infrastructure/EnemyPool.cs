using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    private Vector3 _spawnPosition = new Vector3(0, -10, 0);

    public EnemyPool(Enemy template) : base(template)
    {
    }

    public override Enemy GetObject()
    {
        if (_pool.TryDequeue(out Enemy item) == false)
        {
            Enemy newItem = Object.Instantiate(_template, _spawnPosition, Quaternion.identity);
            newItem.SetPool(this);

            return newItem;
        }

        return item;
    }
}