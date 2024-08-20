using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerUnitMovement : MonoBehaviour
    {
        private IInputService _inputService;
        private float _movementSpeed;
        private Vector2 _horizontalFlyRange;
        private Vector2 _verticalFlyRange;
        private Vector3 unitSize;

        public void Inject(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void SetMovementSpeed(float movementSpeed) => _movementSpeed = movementSpeed;

        public void SetBorders(Vector2 topBorder, Vector2 bottomBorder)
        {
            _horizontalFlyRange = new Vector2(bottomBorder.x, topBorder.x);
            _verticalFlyRange =  new Vector2(bottomBorder.y, topBorder.y );
            unitSize = new Vector3(0.15f, 0.17f, 1.0f);
        }

        public void Update()
        {
            var movement = _inputService.Axis;
            movement *= _movementSpeed * Time.deltaTime;

            if (transform.position.x + movement.x < _horizontalFlyRange.x + unitSize.x)
                movement.x = 0;
            if (transform.position.x + movement.x > _horizontalFlyRange.y - unitSize.x)
                movement.x = 0;
            if (transform.position.y + movement.y < _verticalFlyRange.x + unitSize.y)
                movement.y = 0;
            if (transform.position.y + movement.y > _verticalFlyRange.y - unitSize.y)
                movement.y = 0;
        
            transform.position += (Vector3)movement;
        }
    }
}