using _Project.Scripts.Data;
using UnityEngine;

namespace _Project.Scripts.Levels.SpawnPoints
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private SpawnData _spawnData;
        [SerializeField] private int _prewarmAmount;

        public SpawnData Data => _spawnData;

        public int PrewarmAmount => _prewarmAmount;
    }
}