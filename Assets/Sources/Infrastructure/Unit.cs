using System;
using UnityEngine;
using View;

namespace Infrastructure
{
    public class Unit : MonoBehaviour
    {
        private float _maxHealth;

        public event Action Dying;
        public event Action HealthChanged;
        public event Action GotDamage;

        public float Health { get; protected set; }

        public Vector3 Position => transform.position;

        public void Init(float maxHealth, UnitHelathBar healthBar)
        {
            _maxHealth = maxHealth;
            Health = _maxHealth;
            healthBar.Init(_maxHealth, this);
        }

        public void GetDamage(float damage)
        {
            if (damage <= 0)
            {
                return;
            }

            Health -= damage;

            if (Health <= 0)
            {
                Dying?.Invoke();
            }
            else
            {
                GotDamage?.Invoke();
                HealthChanged?.Invoke();
            }
        }

        public void Heal(float heal)
        {
            if (heal >= 0)
            {
                Health += heal;

                if (Health > _maxHealth)
                {
                    Health = _maxHealth;
                }

                HealthChanged?.Invoke();
            }
        }
    }
}