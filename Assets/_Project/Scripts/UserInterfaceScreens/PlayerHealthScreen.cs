using TMPro;
using UnityEngine;

namespace _Project.Scripts.UserInterfaceScreens
{
    public class PlayerHealthScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthPointText;

        public void SetHealthPointText(string value)
        {
            healthPointText.text = value;
        }
    }
}