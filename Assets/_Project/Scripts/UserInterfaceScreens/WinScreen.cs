using _Project.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UserInterfaceScreens
{
    public class WinScreen : BaseScreen
    {
        [SerializeField] private Button nextLevelButton;

        public void InjectInput(UserInterfaceInputEventBus inputEventBus)
        {
            nextLevelButton.onClick.AddListener(() =>
                {
                    inputEventBus.OnNextLevelButtonTap();
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