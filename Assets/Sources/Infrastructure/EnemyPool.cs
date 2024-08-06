public class EnemyPool : ObjectPool<Enemy>
{
    public EnemyPool(Enemy template) : base(template)
    {
    }
}