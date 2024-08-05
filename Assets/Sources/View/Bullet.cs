using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    private IPool _objectPool;

    public void SetPool(IPool objectPool)
    {
        _objectPool = objectPool;
    }

    public void BackToPool()
    {
        gameObject.SetActive(false);
        _objectPool.Release(this);
    }

    public void Destroy()
    {
        if (_objectPool != null)
        {
            BackToPool();
            return;
        }

        Destroy(gameObject);
    }
}