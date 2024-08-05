using UnityEngine;

public class BulletGeneratorView : MonoBehaviour
{
    [SerializeField] private Bullet _template;

    private BulletPool _bulletPool;

    private void Awake()
    {
        _bulletPool = new BulletPool(_template);

        for (int i = 0; i < 5; i++)
        {
            Bullet bullet = _bulletPool.GetObject();
        }
    }
}