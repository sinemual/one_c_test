using System.Collections.Generic;
using _Project.Scripts.Data;
using UnityEngine;

namespace _Project.Scripts.Enemy
{
    public class EnemyFactory
    {
        private readonly RuntimeData _runtimeData;
        private readonly VfxFactory _vfxFactory;
        private Dictionary<Transform, GameObjectPool> _enemiesPool;

        public EnemyFactory(RuntimeData runtimeData, VfxFactory vfxFactory)
        {
            _runtimeData = runtimeData;
            _vfxFactory = vfxFactory;
            _enemiesPool = new Dictionary<Transform, GameObjectPool>();

        }

        public EnemyUnit Create(EnemyUnitData enemyUnitData, Transform createTransform)
        {
            foreach (var spawnPoint in _runtimeData.CurrentLevel.View.EnemySpawnPoints)
            {
                if (!_enemiesPool.ContainsKey(createTransform))
                    _enemiesPool.Add(createTransform,
                        new GameObjectPool(spawnPoint.Data.EnemyUnitData.Prefab, spawnPoint.PrewarmAmount, _runtimeData.CurrentLevel.View.transform));
            }

            var enemyGo = _enemiesPool[createTransform].GetObjectFromPool();
            enemyGo.transform.SetPositionAndRotation(createTransform.position, createTransform.rotation);

            Vector2 endPoint = new Vector3(createTransform.position.x, _runtimeData.PlayerGetDamageBorderPosition.y, 0.0f);
            var enemyUnit = new EnemyUnit(_vfxFactory, enemyGo, enemyUnitData, createTransform, endPoint, enemyUnitData.EnemyType);
            enemyUnit.Health.Die += () => PoolEnemy(enemyUnit);

            return enemyUnit;
        }

        public void PoolEnemy(EnemyUnit enemy)
        {
            //Debug.Log($"enemy.CreateTransform {enemy.CreateTransform}");
            //Debug.Log($"enemy.View.gameObject {enemy.View.gameObject}");
            _enemiesPool[enemy.CreateTransform].PoolObjectAndPrepare(enemy.View.gameObject);
            enemy.Health.Dispose();
        }
    }
}