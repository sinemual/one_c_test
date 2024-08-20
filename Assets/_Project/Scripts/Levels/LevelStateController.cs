using _Project.Scripts.Data;
using _Project.Scripts.Player;
using _Project.Scripts.UI;
using UnityEngine;

namespace _Project.Scripts.Levels
{
    public class LevelStateController
    {
        private readonly Level _level;
        private readonly UserInterface _userInterface;
        private readonly RuntimeData _runtimeData;
        private readonly SharedData _sharedData;
        
        private PlayerUnit _playerUnit;

        public LevelStateController(Level level, UserInterface userInterface, RuntimeData runtimeData, SharedData sharedData)
        {
            _level = level;
            _userInterface = userInterface;
            _runtimeData = runtimeData;
            _sharedData = sharedData;
        }

        public void CheckLevelComplete()
        {
            _level.DiedEnemyCounter++;
            if (_level.DiedEnemyCounter >= _level.LevelEnemyAmount && _playerUnit.Health.CurrentHealth > 0)
                OnLevelComplete();
        }

        private void OnLevelComplete()
        {
            _runtimeData.CurrentLevelIndex++;
            if (_runtimeData.CurrentLevelIndex >= _sharedData.LevelData.Count) _runtimeData.CurrentLevelIndex = 0;
            _userInterface.WinScreen.Show();
            _level.EnemySetupManager.PoolEnemies();

            Time.timeScale = 0.0f;
        }

        public void OnLevelFailed()
        {
            _userInterface.LoseScreen.Show();
            _level.EnemySetupManager.PoolEnemies();

            Time.timeScale = 0.0f;
        }

        public void SetPlayerUnit(PlayerUnit playerUnit) => _playerUnit = playerUnit;
    }
}