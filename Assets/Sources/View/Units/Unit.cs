using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public event Action Death;

    public float MaxHealth { get; private set; }
    public float Health { get; private set; }

    public Vector3 Position => transform.position;

    public void Init(float maxHealth)
    {
        MaxHealth = maxHealth;
        Health = MaxHealth;
    }

    public void GetDamage(float damage)
    {
        if (damage > 0)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Death.Invoke();
            }
        }
    }
}