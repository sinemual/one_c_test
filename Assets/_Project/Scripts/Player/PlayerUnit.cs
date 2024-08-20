using System;
using _Project.Scripts.Data;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerUnit : IDisposable
    {
        private readonly VfxFactory _vfxFactory;
        private readonly UnitHealth _unitHealth;
        private readonly PlayerView _playerView;
        private readonly DetectSystem _detectSystem;
        private readonly PlayerUnitMovement _movement;
        
        private ShootSystem _shootSystem;
        public UnitHealth Health => _unitHealth;
        public PlayerUnitMovement Movement => _movement;
        
        public PlayerUnit(GameObject go, PlayerUnitData playerUnitData, IInputService inputService, VfxFactory vfxFactory)
        {
            _vfxFactory = vfxFactory;
            
            _playerView = go.GetComponent<PlayerView>();
            _unitHealth = new UnitHealth(playerUnitData.Health);
            _playerView.Init(_unitHealth);
            
            _detectSystem = _playerView.DetectSystem;
            _movement = _playerView.UnitMovement;
            _movement.Inject(inputService);
            _movement.SetMovementSpeed(playerUnitData.MoveSpeed);
            _shootSystem = new PhysicShootSystem(playerUnitData.DefaultWeapon, _playerView.ShotPoint);
            _playerView.ObjectDisabled += _shootSystem.CleanProjectilesPool;
            _detectSystem.SetTarget += OnSetTarget;
            
            _unitHealth.Die += Death;
            _unitHealth.DamageTaken += OnDamageTakenImpact; 
        }

        private void OnSetTarget(Transform target)
        {
            _shootSystem.TryShoot(target);
        }

        private void OnDamageTakenImpact()
        {
            _vfxFactory.Create(VfxType.Hit, _playerView.transform.position);
        }
        
        private void Death()
        {
            _playerView.TurnOffGameObject();
            _detectSystem.LostTarget();
            _vfxFactory.Create(VfxType.Explosion, _playerView.transform.position);
            Dispose();
        }

        public void SetWeapon(WeaponData weaponData)
        {
            _shootSystem.SetWeapon(weaponData, _playerView.ShotPoint); 
            _detectSystem.SetShootRadius(weaponData.ShotRadius);
        }

        public void Dispose()
        {
            _playerView.ObjectDisabled -= _shootSystem.CleanProjectilesPool;
            _detectSystem.SetTarget -= OnSetTarget;
            _unitHealth.Die -= Death;
            _unitHealth.DamageTaken -= OnDamageTakenImpact; 
        }
    }
}