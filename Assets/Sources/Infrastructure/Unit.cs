using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float _maxHealth;

    public event Action OnDeath;
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

            if (Health <= 0)
            {
                OnDeath?.Invoke();
            }
            else
            {
                OnHit?.Invoke();
            }
        }
    }
}