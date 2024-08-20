using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(menuName = "GameData/SharedData", fileName = "SharedData")]
    public class SharedData : ScriptableObject
    {
        [Header("General")]
        public PlayerUnitData PlayerUnitData;
        public List<LevelData> LevelData;
        public List<WeaponData> WeaponData;
    
        [Header("VFXs")]
        public int PrewarmVfxsAmount;
        public VfxByType VfxByType;
    }
}