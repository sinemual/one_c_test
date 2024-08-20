using System;
using System.Collections.Generic;
using _Project.Scripts.Data;
using _Project.Scripts.Enemy;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Levels.SpawnPoints
{
    public class EnemySpawnPointSystem
    {
        public event Action<EnemyUnit> OnSpawn;

        private readonly EnemyFactory _enemyFactory;

        private readonly SpawnData _spawnData;
        private Transform _spawnPointTransform;
        private int _spawnCounter = 0;
        private readonly int _enemyAmount = 0;

        public int EnemyAmount => _enemyAmount;
        
        public EnemySpawnPointSystem(EnemyFactory enemyFactory, Transform spawnPoint, SpawnData spawnData)
        {
            _enemyFactory = enemyFactory;
            _spawnData = spawnData;
            _spawnPointTransform = spawnPoint.transform;

            _spawnCounter = 0;
            _enemyAmount = Random.Range(spawnData.Enemies.x, spawnData.Enemies.y);
            
            StartSpawnWithDelay();
        }

        private async UniTask StartSpawnWithDelay()
        {
            var randomStartSpawnDelay = Random.Range(_spawnData.StartSpawnDelay.x, _spawnData.StartSpawnDelay.y);
            await UniTask.Delay(TimeSpan.FromSeconds(randomStartSpawnDelay), ignoreTimeScale: false);

            var enemyUnit = _enemyFactory.Create(_spawnData.EnemyUnitData, _spawnPointTransform);
            _spawnCounter += 1;
            OnSpawn?.Invoke(enemyUnit);
            await NextSpawnWithDelay();
        }

        private async UniTask NextSpawnWithDelay()
        {
            var randomSpawnDelay = Random.Range(_spawnData.SpawnIntervalTime.x, _spawnData.SpawnIntervalTime.y);
            await UniTask.Delay(TimeSpan.FromSeconds(randomSpawnDelay), ignoreTimeScale: false);

            var enemyUnit = _enemyFactory.Create(_spawnData.EnemyUnitData, _spawnPointTransform);
            _spawnCounter += 1;
            OnSpawn?.Invoke(enemyUnit);
            if (_spawnCounter >= EnemyAmount)
                return;
            await NextSpawnWithDelay();
        }

        
    }
}