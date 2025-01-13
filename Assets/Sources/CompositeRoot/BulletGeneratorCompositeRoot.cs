using Infrastructure;
using UnityEngine;
using View;
using View.Generators;
using View.PlayerComponents;

namespace Root
{
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
}