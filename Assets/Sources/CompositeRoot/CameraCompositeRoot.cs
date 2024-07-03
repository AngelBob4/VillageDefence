using UnityEngine;

public class CameraCompositeRoot : CompositeRoot
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraFollowingView _cameraFollowingView;

    public override void Compose()
    {
    }

    public void Init(Player player)
    {
        _cameraFollowingView.Init(player);
    }
}