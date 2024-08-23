using UnityEngine;
using System.Collections;

public class EnemyGeneratorView : GeneratorView
{
    private EnemyPool _enemyPool;
    private Player _player;

    private int _waveCounter = 0;
    private int _startAmountOfEnemies = 2;

    private float _enemyMaxHealth = 20f;
    private float _spawnRadius = 7f;
    private WaitForSeconds _spawnDelay;
    private Coroutine _currentCoroutine;

    private Particle _hit;
    private ParticleSystem _death;

    public void Init(Enemy template, Player player, float spawnDelay, Particle hit, ParticleSystem death)
    {
        _enemyPool = new EnemyPool(template);
        _player = player;
        _spawnDelay = new WaitForSeconds(spawnDelay);
        _hit = hit;
        _death = death;
    }

    public void StartNextWave()
    {
        int amountOfEnemies = _startAmountOfEnemies + _waveCounter;
        _currentCoroutine = StartCoroutine(GenerateWave(amountOfEnemies));
        _waveCounter++;
    }

    private IEnumerator GenerateWave(int amountOfEnemies)
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Enemy enemy = _enemyPool.GetObject();
            enemy.Init(_enemyMaxHealth, _hit, _death);
            SetPositionOnRadius(enemy.gameObject, _spawnRadius, _player);

            yield return _spawnDelay;
        }
    }
}