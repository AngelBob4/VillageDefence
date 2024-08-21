public class AttackZone
{   
    public Enemy Target { get; private set; } = null;

    private Gun _gun;
    private PlayerAnimator  _playerAnimator;
    private Inventory  _inventory;
    
    public AttackZone(Gun gun, PlayerAnimator playerAnimator, Inventory inventory)
    {
        _gun = gun;
        _playerAnimator = playerAnimator;
        _inventory = inventory;
    }

    public void TrySetTarget(Enemy enemy)
    {
        if (Target == null)
        {
            Target = enemy;
        }
    }

    public void Update()
    {
        if (Target != null)
        {
            if (Target.isActiveAndEnabled == false)
            {
                Target = null;
            }
            else if(_inventory.HasBullets)
            {
                _gun.Shoot(Target);
                _playerAnimator.Shoot();
            }
        }
    }

    public void ResetTarget()
    {
        Target = null;
    }
}