using UnityEngine;

public class EnemyGeneratorRoot : CompositeRoot
{
    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Enemy _template;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGeneratorView _enemyGeneratorView;

    private float _spawnDelay = 1f;

    public override void Compose()
    {
        _enemyGeneratorView.Init(_template, _player, _spawnDelay);
    }
}