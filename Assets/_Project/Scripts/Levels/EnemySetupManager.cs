using System.Collections.Generic;
using _Project.Scripts.Enemy;
using _Project.Scripts.Levels.SpawnPoints;

namespace _Project.Scripts.Levels
{
    public class EnemySetupManager
    {
        private readonly Level _level;
        private readonly EnemyFactory _enemyFactory;
        private List<EnemyUnit> _enemies;
        private List<EnemySpawnPointSystem> _enemySpawnPointSystems;

        public EnemySetupManager(Level level, EnemyFactory enemyFactory)
        {
            _level = level;
            _enemyFactory = enemyFactory;
        }

        public void EnemyUnitsInit()
        {
            var levelEnemyAmount = 0;
            _enemies = new List<EnemyUnit>();
            _enemySpawnPointSystems = new List<EnemySpawnPointSystem>();
            foreach (var enemySpawnPoint in _level.View.EnemySpawnPoints)
            {
                var spawnManager = new EnemySpawnPointSystem(_enemyFactory, enemySpawnPoint.transform, enemySpawnPoint.Data);
                _enemySpawnPointSystems.Add(spawnManager);
                levelEnemyAmount += spawnManager.EnemyAmount;
                spawnManager.OnSpawn += (enemyUnit) =>
                {
                    enemyUnit.Health.Die += _level.LevelStateController.CheckLevelComplete;
                    enemyUnit.Behaviour.PlayerDamaged += () => _level.PlayerSetupManager.OnEnemyGetPlayer(enemyUnit.UnitData.Damage);
                    _enemies.Add(enemyUnit);
                };
            }

            _level.LevelEnemyAmount = levelEnemyAmount;
        }

        public void PoolEnemies()
        {
            foreach (var enemy in _enemies) _enemyFactory.PoolEnemy(enemy);
        }
    }
}