using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(menuName = "GameData/PlayerUnitData", fileName = "PlayerUnitData")]
    public class PlayerUnitData : ScriptableObject
    {
        public GameObject Prefab;
        public int Health;
        public float MoveSpeed;
        public WeaponData DefaultWeapon;
    }
}