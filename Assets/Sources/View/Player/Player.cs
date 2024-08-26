using UnityEngine;

public class Player : Unit
{
    public new void Init(float maxHealth)
    {
        OnDeath += Death;
        base.Init(maxHealth);
    }

    private void Death()
    {
        Destroy(this);
    }
}