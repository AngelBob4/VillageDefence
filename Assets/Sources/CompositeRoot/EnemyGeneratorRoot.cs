using UnityEngine;

public class EnemyGeneratorRoot : CompositeRoot
{
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Enemy _template;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGeneratorView _enemyGeneratorView;

    private float _spawnDelay = 1f;
    private int _timeBetweenWaves = 15;
    private EnemyGenerator _enemyGenerator;

    public override void Compose()
    {
        _enemyGenerator = new EnemyGenerator(_enemyGeneratorView, _timeBetweenWaves);
        _enemyGeneratorView.Init(_template, _player, _spawnDelay);
    }
}