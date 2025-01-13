using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class ObjectPool<T> : IPool
    where T : UnityEngine.Object, IPoolable
    {
        protected T Template;
        protected Queue<T> Pool;

        public ObjectPool(T template)
        {
            Template = template;
            Pool = new Queue<T>();
        }

        public event Action ObjectReturned;

        public virtual T GetObject()
        {
            if (Pool.TryDequeue(out T item) == false)
            {
                T newItem = UnityEngine.Object.Instantiate(Template);
                newItem.SetPool(this);

                return newItem;
            }

            return item;
        }

        public virtual void Release(IPoolable item)
        {
            Pool.Enqueue(item as T);
            ObjectReturned?.Invoke();
        }
    }
}