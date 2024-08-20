using System;

namespace _Project.Scripts.UI
{
    public class UserInterfaceInputEventBus
    {
        public event Action RestartLevelButtonTap;
        public event Action NextLevelButtonTap;

        public void OnNextLevelButtonTap() => NextLevelButtonTap?.Invoke();

        public void OnRestartLevelButtonTap() => RestartLevelButtonTap?.Invoke();
    }
}