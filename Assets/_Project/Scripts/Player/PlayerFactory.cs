using _Project.Scripts.Data;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerFactory
    {
        private IInputService _inputService;
        private VfxFactory _vfxFactory;
        private RuntimeData _runtimeData;
    
        private PlayerFactory(IInputService inputService, VfxFactory vfxFactory)
        {
            _inputService = inputService;
            _vfxFactory = vfxFactory;
        }
    
        public PlayerUnit Create(PlayerUnitData playerUnitData, Transform createTransform)
        {
            var go = Object.Instantiate(playerUnitData.Prefab, createTransform.position, createTransform.rotation, createTransform);
            var playerUnit = new PlayerUnit(go, playerUnitData, _inputService, _vfxFactory);
            return playerUnit;
        }
    }
}