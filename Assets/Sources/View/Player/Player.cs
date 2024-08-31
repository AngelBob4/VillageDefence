public class Player : Unit
{
    public new void Init(float maxHealth, UnitHelathBar healthBar)
    {
        OnDeath += Death;
        base.Init(maxHealth, healthBar);
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }

    public void UpgradePlayer()
    {
        Death();
    }
}