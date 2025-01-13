using Infrastructure;
using UnityEngine;
using View;
using View.PlayerComponents;

namespace Root
{
    public class CameraCompositeRoot : CompositeRoot
    {
        [SerializeField] private Player _player;
        [SerializeField] private CameraFollowingView _cameraFollowingView;

        public override void Compose()
        {
            _cameraFollowingView.Init(_player);
        }
    }
}