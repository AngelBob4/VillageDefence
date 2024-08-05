using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : IPool
    where T : Object, IPoolable
{
    private T _template;
    private Queue<T> _pool;

    public ObjectPool(T template)
    {
        _template = template;
        _pool = new Queue<T>();
    }

    public T GetObject()
    {
        if (_pool.TryDequeue(out T item) == false)
        {
            T newItem = Object.Instantiate(_template);
            newItem.SetPool(this);

            return newItem;
        }
        
        return item;
    }

    public void Release(IPoolable item)
    {
        _pool.Enqueue(item as T);
    }
}