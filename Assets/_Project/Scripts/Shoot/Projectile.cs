using System;
using _Project.Scripts.Enemy;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public event Action Hit;
    
    private int _damage;
    public void InitDamage(int damage) => _damage = damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col)
            if (col.TryGetComponent(out EnemyView enemyView))
            {
                enemyView.UnitData.Health.TakeDamage(_damage);
                Hit?.Invoke();
            }
    }
}