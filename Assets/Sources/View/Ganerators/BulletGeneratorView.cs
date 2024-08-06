using UnityEngine;

public class BulletGeneratorView : MonoBehaviour
{
    [SerializeField] private Bullet _template;
    [SerializeField] private Player _player;

    private BulletPool _bulletPool;
    private int _maxBulletsAmount = 10;

    private void Awake()
    {
        _bulletPool = new BulletPool(_template, _maxBulletsAmount);

        for (int i = 0; i < 15; i++)
        {
            Bullet bullet = _bulletPool.GetObject();
        }
    }
}