using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private EnemyPool _enemyPool;
    private Player _player;
    private Particle _hit;
    private ParticleSystem _death;
    private float _enemyMaxHealth = 20f;

    public EnemyPool EnemyPool => _enemyPool;

    public void Init(Enemy template, Player player, Particle hit, ParticleSystem death)
    {
        _enemyPool = new EnemyPool(template);
        _player = player;
        _hit = hit;
        _death = death;
    }

    public Enemy Create()
    {
        Enemy enemy = _enemyPool.GetObject();
        enemy.Init(_enemyMaxHealth, _hit, _death, _player.transform);
        return enemy;
    }

    public void ResetPool(int amountOfEnemies)
    {
        _enemyPool.Reset(amountOfEnemies);
    }
}