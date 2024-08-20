using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UserInterfaceScreens
{
    public class BorderScreen : MonoBehaviour
    {
        [SerializeField] private Image _rootImage;

        private readonly Vector3[] _corners = new Vector3[4];
    
        private void Awake() => CalculateCorners();

        private void CalculateCorners() => _rootImage.rectTransform.GetWorldCorners(_corners);

        public Vector3 GetTopRightCorner()
        {
            var position = Camera.main.ScreenToWorldPoint(_corners[2]);
            position = new Vector3(position.x, position.y, 0.0f);
            return position;
        }

        public Vector3 GetLeftBottomCorner()
        {
            var position = Camera.main.ScreenToWorldPoint(_corners[0]);
            position = new Vector3(position.x, position.y, 0.0f);
            return position;
        }

        public void SetTopBorder(float value)
        {
            float newHeight =  value * 10.0f;
            float heightDifference = newHeight - _rootImage.rectTransform.sizeDelta.y;
            Vector2 offsetMax = _rootImage.rectTransform.offsetMax;
            offsetMax.y += heightDifference;
            _rootImage.rectTransform.offsetMax = offsetMax;
            CalculateCorners();
        }
    }
}