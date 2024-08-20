using System;
using UnityEngine;

public class UnitHealth : IDisposable
{
    public event Action Die;
    public event Action<int> UpdateHealth;
    public event Action DamageTaken;
    
    private bool _isDead;

    private int currentHealth;

    public int CurrentHealth => currentHealth;

    public bool IsDead => _isDead;

    public UnitHealth(int health)
    {
        currentHealth = health;
        _isDead = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = CurrentHealth - damage;
        UpdateHealth?.Invoke(CurrentHealth);
        DamageTaken?.Invoke();
        if (CurrentHealth <= 0)
        {
            _isDead = true;
            Die?.Invoke();
        }
    }

    public void Death() => TakeDamage(CurrentHealth);

    public void Dispose()
    {
        Die = null;
    }
}