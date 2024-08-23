using UnityEngine;

public class EnemyGeneratorCompositeRoot : CompositeRoot
{
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Enemy _template;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGeneratorView _enemyGeneratorView;
    [SerializeField] private Particle _hit;
    [SerializeField] private ParticleSystem _death;

    private float _spawnDelay = 1f;
    private int _timeBetweenWaves = 15;
    private EnemyGenerator _enemyGenerator;

    private void Update()
    {
        _enemyGenerator.Tick(Time.deltaTime);
    }

    public override void Compose()
    {
        _enemyGeneratorView.Init(_template, _player, _spawnDelay, _hit, _death);
        _enemyGenerator = new EnemyGenerator(_enemyGeneratorView, _timeBetweenWaves);
        _enemyGenerator.StartWave();
    }
}