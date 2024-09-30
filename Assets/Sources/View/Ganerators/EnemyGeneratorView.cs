using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyGeneratorView : Generator
{
    private Player _player;
    private EnemyFactory _enemyFactory;
    private EnemyGenerator _enemyGenerator;
    private Coroutine _currentCoroutine;
    private EnemyGeneratorPresenter _enemyGeneratorPresenter;

    private Vector3 _enemyOffset = new Vector3(0, 0.1f, 0);
    private float _spawnRadius = 7f;
    private WaitForSeconds _spawnDelay;
    private float _delay = 1f;

    public EnemyGeneratorPresenter EnemyGeneratorPresenter => _enemyGeneratorPresenter;

    public void Init(Player player, EnemyFactory enemyFactory, EnemyGenerator enemyGenerator, Game game, Text waveCompleted)
    {
        _enemyGenerator = enemyGenerator;
        _player = player;
        _spawnDelay = new WaitForSeconds(_delay);
        _enemyFactory = enemyFactory;
        _enemyGeneratorPresenter = new EnemyGeneratorPresenter(_enemyFactory.EnemyPool, game, _enemyGenerator, waveCompleted);
    }

    public void StartNextWave(int amountOfEnemies)
    {
        _enemyGeneratorPresenter.Reset(amountOfEnemies);
        _currentCoroutine = StartCoroutine(GenerateWave(amountOfEnemies));
    }

    private IEnumerator GenerateWave(int amountOfEnemies)
    {
        if (_enemyGenerator.WaveCounter % 3 == 0)
            _enemyFactory.ResetEnemyParametrs(2, 0);

        if (_enemyGenerator.WaveCounter % 5 == 0)
            _enemyFactory.ResetEnemyParametrs(0, 2);

        for (int i = 0; i < amountOfEnemies; i++)
        {
            Enemy enemy = _enemyFactory.Create();
            SetPositionOnRadius(enemy.gameObject, _spawnRadius, _player);
            enemy.gameObject.transform.position += _enemyOffset;
            enemy.gameObject.SetActive(true);

            yield return _spawnDelay;
        }
    }
}