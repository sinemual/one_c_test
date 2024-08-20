using System;
using _Project.Scripts.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Enemy
{
    public class EnemyUnit : IDisposable
    {
        public EnemyBehaviour Behaviour { get; private set; }
        public EnemyUnitData UnitData { get;}
        public EnemyView View { get;}
        public UnitHealth Health { get;}

        public Transform CreateTransform => _createTransform;

        private VfxFactory _vfxFactory;
        
        private Transform _createTransform;

        public EnemyUnit(VfxFactory vfxFactory, GameObject enemyGo, EnemyUnitData enemyUnitData, Transform createTransform, Vector2 endPoint, EnemyType enemyType)
        {
            _vfxFactory = vfxFactory;
            UnitData = enemyUnitData;
            View = enemyGo.GetComponent<EnemyView>();
            Health = new UnitHealth(enemyUnitData.Health);
            
            switch (enemyUnitData.EnemyType)
            {
                case EnemyType.Linear:
                    InitBehaviour(new LinearEnemyBehaviour(), endPoint, createTransform);
                    break;
            }
        }

        private void InitBehaviour(EnemyBehaviour enemyBehaviour, Vector2 endPoint, Transform createTransform)
        {
            _createTransform = createTransform;
            View.Init(this);
            var speed = Random.Range(UnitData.MoveSpeed.x, UnitData.MoveSpeed.y);
            Behaviour = enemyBehaviour;
            Behaviour.StartMove(View.transform, speed, endPoint);
            Behaviour.PlayerDamaged += OnPlayerDamaged;
            Health.DamageTaken += TakeDamageImpact;
            Health.Die += Death;
        }

        private void Death()
        {
            Behaviour.StopMove(View.transform);
            _vfxFactory.Create(VfxType.Explosion, View.transform.position);
            Dispose();
        }

        private void TakeDamageImpact() => _vfxFactory.Create(VfxType.Hit, View.transform.position);


        private void OnPlayerDamaged()
        {
            Health.Death();
        }

        public void Dispose()
        {
            Behaviour.PlayerDamaged -= OnPlayerDamaged;
            Health.DamageTaken -= TakeDamageImpact;
            Health.Die -= Death;
        }
    }
}