public class BulletPool : ObjectPool<Bullet>
{
    public BulletPool(Bullet template) : base(template)
    {
    }
}