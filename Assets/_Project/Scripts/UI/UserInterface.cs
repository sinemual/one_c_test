using _Project.Scripts.Data;
using _Project.Scripts.UserInterfaceScreens;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
    public class UserInterface : MonoBehaviour
    {
        public WinScreen WinScreen;
        public LoseScreen LoseScreen;
        public PlayerHealthScreen PlayerHealthScreen;
        public BorderScreen BorderScreen;

        [Inject]
        public void Construct(UserInterfaceInputEventBus userInterfaceInputEventBus, RuntimeData runtimeData, SharedData sharedData)
        {
            Init(userInterfaceInputEventBus);
        }

        private void Init(UserInterfaceInputEventBus inputEventBus)
        {
            WinScreen.InjectInput(inputEventBus);
            LoseScreen.InjectInput(inputEventBus);
        }
    }
}