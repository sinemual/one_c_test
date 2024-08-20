using System.Collections.Generic;
using _Project.Scripts.Data;
using _Project.Scripts.Enemy;
using _Project.Scripts.Player;
using _Project.Scripts.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Levels
{
    public class LevelFactory
    {
        private SharedData _sharedData;
        private List<LevelData> _levelData;
        private RuntimeData _runtimeData;
        private UserInterface _userInterface;
        private EnemyFactory _enemyFactory;
        private PlayerFactory _playerFactory;

        private LevelData _currentLevelData;

        public LevelFactory(SharedData sharedData, RuntimeData runtimeData, UserInterface userInterface, EnemyFactory enemyFactory, PlayerFactory playerFactory)
        {
            _sharedData = sharedData;
            _levelData = sharedData.LevelData;
            _runtimeData = runtimeData;
            _userInterface = userInterface;
            _enemyFactory = enemyFactory;
            _playerFactory = playerFactory;
        }

        public void CreateNewLevel(int num)
        {
            _currentLevelData = _levelData[num];

            var go = Object.Instantiate(_currentLevelData.Prefab);

            var levelView = go.GetComponent<LevelView>();
            var level = new Level(_sharedData, _runtimeData, _userInterface, _enemyFactory, _playerFactory);
            
            level.Init(levelView, _currentLevelData);
            level.Setup();
            
            _runtimeData.CurrentLevel = level;
            Time.timeScale = 1.0f;
        }
    }
}