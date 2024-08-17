using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour, IPoolable
{
    private IPool _objectPool;

    public void SetPool(IPool objectPool)
    {
        _objectPool = objectPool;
    }

    public void Reset()
    {
        gameObject.transform.parent = null;
        gameObject.SetActive(true);
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

    public void BackToPool()
    {
        gameObject.SetActive(false);
        _objectPool.Release(this);
    }
}