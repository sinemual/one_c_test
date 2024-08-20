using System;
using _Project.Scripts.Data;
using _Project.Scripts.UI;

namespace _Project.Scripts.Levels
{
    public class LevelCreator : IDisposable
    {
        private readonly LevelFactory _levelFactory;
        private readonly RuntimeData _runtimeData;
        private readonly UserInterfaceInputEventBus _userInterfaceInputEventBus;

        private LevelCreator(LevelFactory levelFactory, RuntimeData runtimeData, UserInterfaceInputEventBus userInterfaceInputEventBus)
        {
            _levelFactory = levelFactory;
            _runtimeData = runtimeData;
            _userInterfaceInputEventBus = userInterfaceInputEventBus;
        }

        public void Initialize()
        {
            _levelFactory.CreateNewLevel(_runtimeData.CurrentLevelIndex);
            
            _userInterfaceInputEventBus.NextLevelButtonTap += StartNextLevel;
            _userInterfaceInputEventBus.RestartLevelButtonTap += StartNextLevel;
        }

        private void StartNextLevel()
        {
            DestroyPrevious();
            _levelFactory.CreateNewLevel(_runtimeData.CurrentLevelIndex);
        }

        private void DestroyPrevious()
        {
            if (_runtimeData.CurrentLevel.View)
                UnityEngine.Object.Destroy(_runtimeData.CurrentLevel.View.gameObject);
        }

        public void Dispose()
        {
            _userInterfaceInputEventBus.NextLevelButtonTap -= StartNextLevel;
            _userInterfaceInputEventBus.RestartLevelButtonTap -= StartNextLevel;
        }
    }
}