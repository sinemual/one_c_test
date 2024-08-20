using _Project.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UserInterfaceScreens
{
    public class LoseScreen : BaseScreen
    {
        [SerializeField] private Button restartLevelButton;

        public void InjectInput(UserInterfaceInputEventBus inputEventBus)
        {
            restartLevelButton.onClick.AddListener(() =>
                {
                    inputEventBus.OnRestartLevelButtonTap();
                    gameObject.SetActive(false);
                }
            );
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }
    }
}