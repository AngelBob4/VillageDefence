using UnityEngine;

public class PlayerCompositeRoot : CompositeRoot
{
    [SerializeField] private Player _player;

    private Gun _gun;
    private PlayerAnimator _playerAnimator;
    private AttackZone _attackZone;
    private PlayerInputRouter _playerInputRouter;

    public override void Compose()
    {
        _player.Init();
        _playerInputRouter = _player.PlayerInputRouter;
        _attackZone = _player.AttackZone;
        _playerAnimator = _player.PlayerAnimator;
        _gun = _player.Gun;
    }

    private void Update()
    {
        _player.Tick(Time.deltaTime);
        _playerInputRouter.Update();
        _attackZone.Update();
        _playerAnimator.Update();
        _gun.Tick(Time.deltaTime);
    }
}