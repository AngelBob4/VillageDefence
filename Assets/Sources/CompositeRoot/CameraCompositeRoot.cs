using UnityEngine;

public class CameraCompositeRoot : CompositeRoot
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraFollowingView _cameraFollowingView;

    public override void Compose()
    {
        _cameraFollowingView.Init(_player);
    }
}