using NaughtyAttributes;
using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(menuName = "GameData/EnemyUnitData", fileName = "EnemyUnitData")]
    public class EnemyUnitData : ScriptableObject
    {
        public GameObject Prefab;
        [MinMaxSlider(0.1f, 1.2f)]
        public Vector2 MoveSpeed;
        public int Health;
        public int Damage;
        public EnemyType EnemyType;
    }
}