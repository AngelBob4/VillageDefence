using System;
using System.Collections.Generic;
using View.EnemyComponents;

namespace Infrastructure
{
    public class EnemyPool
    {
        private Dictionary<int, ObjectPool<Enemy>> _poolByTemplateId = new Dictionary<int, ObjectPool<Enemy>>();
        private List<Enemy> _templates = new List<Enemy>();
        private Random _random = new Random();

        public EnemyPool(List<Enemy> templates)
        {
            _templates = templates;

            foreach (Enemy enemy in _templates)
            {
                ObjectPool<Enemy> objectPool = new ObjectPool<Enemy>(enemy);
                _poolByTemplateId.Add(enemy.GetInstanceID(), objectPool);
                objectPool.ObjectReturned += OnObjectReturned;
            }
        }

        ~EnemyPool()
        {
            foreach (ObjectPool<Enemy> objectPool in _poolByTemplateId.Values)
            {
                objectPool.ObjectReturned -= OnObjectReturned;
            }
        }

        public event Action EnemyReturned;

        public Enemy GetObject()
        {
            int randomNumber = _random.Next(0, _templates.Count);
            int templateId = _templates[randomNumber].GetInstanceID();

            Enemy newItem = _poolByTemplateId[templateId].GetObject();
            newItem.gameObject.SetActive(false);

            return newItem;
        }

        private void OnObjectReturned()
        {
            EnemyReturned?.Invoke();
        }
    }
}