using UnityEngine;
using System.Collections;

public class EnemyGeneratorView : MonoBehaviour
{
    private EnemyPool _enemyPool;
    private Player _player;

    private int _waveCounter = 0;
    private int _startAmountOfEnemies = 10;
    private WaitForSeconds _spawnDelay;

    public void Init(Enemy template, Player player, float spawnDelay)
    {
        _enemyPool = new EnemyPool(template);
        _player = player;
        _spawnDelay = new WaitForSeconds(spawnDelay);

        StartNextWave();
    }

    public void StartNextWave()
    {
        StartCoroutine(GenerateWave(_startAmountOfEnemies));
        _waveCounter++;
    }

    private IEnumerator GenerateWave(int amountOfEnemies)
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Enemy enemy = _enemyPool.GetObject();
            enemy.gameObject.SetActive(true);

            yield return _spawnDelay;
        }
    }
}