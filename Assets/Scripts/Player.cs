using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float Health;
    [SerializeField] private float MaxHealth;

    public event UnityAction HealthChanged;
    private float _healthChanging = 10;

    public void Heal(float healthChanging)
    {
        if (Health < MaxHealth && Health > 0)
        {
            Health += healthChanging;
            HealthChanged?.Invoke();
        }
    }

    public void TakeDamage(float healthChanging)
    {
        if (Health < MaxHealth && Health > 0)
        {
            Health -= healthChanging;
            HealthChanged?.Invoke();
        }
    }

    public float GetHealth()
    {
        return Health;
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }
}
