using UnityEngine;

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
        if (_pool.TryDequeue(out Bullet item) == false)
        {
            if (_currentBulletsAmount < _maxBulletsAmount)
            {
                Bullet newItem = Object.Instantiate(_template);
                _currentBulletsAmount++;
                newItem.SetPool(this);

                return newItem;
            }
            else
            {
                return null;
            }
        }

        return item;
    }
}