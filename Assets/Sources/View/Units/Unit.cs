using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float _maxHealth;

    public event Action Death;
    public event Action OnHit;

    public float Health { get; private set; }

    public Vector3 Position => transform.position;

    public void Init(float maxHealth)
    {
        _maxHealth = maxHealth;
        Health = _maxHealth;
    }

    public void GetDamage(float damage)
    {
        if (damage > 0)
        {
            Health -= damage;
            OnHit?.Invoke();

            if (Health <= 0)
            {
                Death?.Invoke();
            }
        }
    }
}