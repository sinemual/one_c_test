using System.Collections.Generic;
using _Project.Scripts.Levels.SpawnPoints;
using UnityEngine;

namespace _Project.Scripts.Levels
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private List<EnemySpawnPoint> enemySpawnPoints;

        public Transform PlayerSpawnPoint => playerSpawnPoint;
        public List<EnemySpawnPoint> EnemySpawnPoints => enemySpawnPoints;
    }
}