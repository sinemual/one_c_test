using System;
using System.Collections.Generic;
using _Project.Scripts.Enemy;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class DetectSystem : MonoBehaviour
    {
        public event Action<Transform> SetTarget;

        private readonly Queue<EnemyUnit> _enemies = new Queue<EnemyUnit>();
        private EnemyUnit _currentTarget;
        private float _radius;

        public void SetShootRadius(float radius)
        {
            _radius = radius;
            GetComponent<CircleCollider2D>().radius = _radius;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col)
            {
                if (col.TryGetComponent(out EnemyView enemyView))
                {
                    var enemyUnit = enemyView.UnitData;
                    if (!_enemies.Contains(enemyUnit))
                    {
                        _enemies.Enqueue(enemyUnit);
                        if (_currentTarget == null)
                            NextTarget();
                    }
                }
            }
        }

        private void NextTarget()
        {
            _currentTarget = null;
            if (_enemies.Count > 0)
            {
                _currentTarget = _enemies.Dequeue();
                if (_currentTarget.Health.IsDead)
                {
                    NextTarget();
                    return;
                }
                _currentTarget.Health.Die += NextTarget;
                SetTarget?.Invoke(_currentTarget.View.transform);
            }
        }

        public void LostTarget()
        {
            _currentTarget = null;
        }
    }
}