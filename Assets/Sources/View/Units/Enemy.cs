public class Enemy : Unit, IPoolable
{
    private IPool _pool;

    public new void Init(float maxHealth)
    {
        base.Init(maxHealth);
    }

    public void SetPool(IPool objectPool)
    {
        _pool = objectPool;
    }

    public void BackToPool()
    {
        gameObject.SetActive(false);
        _pool.Release(this);
    }

    public void Destroy()
    {
        if (_pool != null)
        {
            BackToPool();
            return;
        }

        Destroy(gameObject);
    }
}