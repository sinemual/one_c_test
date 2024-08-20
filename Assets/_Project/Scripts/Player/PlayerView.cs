using System;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerView : MonoBehaviour, IDisposable
    {
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private SpriteRenderer _playerImage;
        [SerializeField] private Sprite[] _degreeDamageSprites;
        [SerializeField] private DetectSystem _detectSystem;
        [SerializeField] private PlayerUnitMovement _playerUnitMovement;

        public event Action ObjectDisabled;
        
        private UnitHealth _unitHealth;

        public Transform ShotPoint => _shotPoint;

        public DetectSystem DetectSystem => _detectSystem;

        public PlayerUnitMovement UnitMovement => _playerUnitMovement;

        public void Init(UnitHealth unitHealth)
        {
            _unitHealth = unitHealth;
            _unitHealth.DamageTaken += UpdateShipState;
        }

        public void TurnOffGameObject()
        {
            gameObject.SetActive(false);
            Dispose();
        }

        private void UpdateShipState()
        {
            if (_unitHealth.CurrentHealth > 0)
                _playerImage.sprite = _degreeDamageSprites[4 - _unitHealth.CurrentHealth];
        }

        public void Dispose() => _unitHealth.DamageTaken -= UpdateShipState;

        private void OnDisable() => ObjectDisabled?.Invoke();
    }
}