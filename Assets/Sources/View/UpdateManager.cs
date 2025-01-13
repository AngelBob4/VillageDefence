using InputSystem;
using Model;
using Model.EnemyComponents;
using Model.PlayerComponents;
using UnityEngine;
using View.PlayerComponents;

public class UpdateManager : MonoBehaviour
{
    private EnemyGenerator _enemyGenerator;
    private Player _player;
    private PlayerInputRouter _playerInputRouter;
    private AttackZone _attackZone;
    private PlayerAnimator _playerAnimator;
    private Gun _gun;

    public void Init(EnemyGenerator enemyGenerator,
        Player player,
        PlayerInputRouter playerInputRouter,
        AttackZone attackZone,
        PlayerAnimator playerAnimator,
        Gun gun)
    {
        _enemyGenerator = enemyGenerator;
        _player = player;
        _playerInputRouter = playerInputRouter;
        _attackZone = attackZone;
        _playerAnimator = playerAnimator;
        _gun = gun;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        _enemyGenerator.Tick(Time.deltaTime);
        _player.Tick(Time.deltaTime);
        _playerInputRouter.Update();
        _attackZone.Update();
        _playerAnimator.Update();
        _gun.Tick(Time.deltaTime);
    }
}