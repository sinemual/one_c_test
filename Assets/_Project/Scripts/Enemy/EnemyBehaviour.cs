using System;
using UnityEngine;

namespace _Project.Scripts.Enemy
{
    public abstract class EnemyBehaviour
    {
        public event Action PlayerDamaged;
        public abstract void StartMove(Transform transform, float speed, Vector2 endPoint);
        public abstract void StopMove(Transform transform);
        protected void InvokePlayerDamaged() => PlayerDamaged?.Invoke();
    }
}