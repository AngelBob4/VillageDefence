using UnityEngine;

public class BulletGeneratorCompositeRoot : CompositeRoot
{
    [SerializeField] private Bullet _template;
    [SerializeField] private Player _player;
    [SerializeField] private BulletGeneratorView _bulletGeneratorView;

    public override void Compose()
    {
        _bulletGeneratorView.Init(_template, _player);
    }
}