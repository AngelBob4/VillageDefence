using UnityEngine;

public class EnemyGeneratorCompositeRoot : CompositeRoot
{
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Enemy _template;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGeneratorView _enemyGeneratorView;
    [SerializeField] private Particle _hit;
    [SerializeField] private ParticleSystem _death;
    [SerializeField] private EnemyFactory _enemyFactory;

    private EnemyGenerator _enemyGenerator;

    private void Update()
    {
        _enemyGenerator.Tick(Time.deltaTime);
    }

    public override void Compose()
    {
        _enemyFactory.Init(_template, _player, _hit, _death);
        _enemyGeneratorView.Init(_player, _enemyFactory);
        _enemyGenerator = new EnemyGenerator(_enemyGeneratorView);
    }
}