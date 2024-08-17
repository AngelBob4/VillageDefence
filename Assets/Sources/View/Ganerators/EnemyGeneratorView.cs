using UnityEngine;
using System.Collections;

public class EnemyGeneratorView : GeneratorView
{
    private EnemyPool _enemyPool;
    private Player _player;

    private int _waveCounter = 0;
    private int _startAmountOfEnemies = 10;
    private WaitForSeconds _spawnDelay;
    private float _spawnRadius = 10f;
    private Coroutine _currentCoroutine;

    public void Init(Enemy template, Player player, float spawnDelay)
    {
        _enemyPool = new EnemyPool(template);
        _player = player;
        _spawnDelay = new WaitForSeconds(spawnDelay);
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
            SetPositionOnRadius(enemy.gameObject, _spawnRadius, _player);

            yield return _spawnDelay;
        }
    }
}