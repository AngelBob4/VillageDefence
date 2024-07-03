public class AttackZone
{   
    public Enemy Target { get; private set; } = null;

    private Gun _gun;
    
    public AttackZone(Gun gun)
    {
        _gun = gun;
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
            else
            {
                _gun.TryToShoot(Target);
            }
        }
    }

    public void ResetTarget()
    {
        Target = null;
    }
}