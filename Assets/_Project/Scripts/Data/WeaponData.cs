using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(menuName = "GameData/WeaponData", fileName = "WeaponData")]
    public class WeaponData : ScriptableObject
    {
        public GameObject ProjectilePrefab;
        public float ShotRadius;
        public float ReloadTime;
        public int Damage;
        public float BulletSpeed;
    }
}