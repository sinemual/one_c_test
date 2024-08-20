using UnityEngine;

namespace _Project.Scripts.Data
{
    [CreateAssetMenu(menuName = "GameData/LevelData", fileName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        public GameObject Prefab;
        [Range(1.0f, 115.0f)]
        public float PlayerFlyRange;
    }
}
