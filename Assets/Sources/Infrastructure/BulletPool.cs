using UnityEngine;
using View;

namespace Infrastructure
{
    public class BulletPool : ObjectPool<Bullet>
    {
        private int _maxBulletsAmount;
        private int _currentBulletsAmount = 0;

        public BulletPool(Bullet template, int maxBulletsAmount) : base(template)
        {
            _maxBulletsAmount = maxBulletsAmount;
        }

        public override Bullet GetObject()
        {
            if (Pool.TryDequeue(out Bullet item) == false)
            {
                if (_currentBulletsAmount < _maxBulletsAmount)
                {
                    Bullet newItem = Object.Instantiate(Template);
                    _currentBulletsAmount++;
                    newItem.SetPool(this);

                    return newItem;
                }
            }

            return item;
        }
    }
}