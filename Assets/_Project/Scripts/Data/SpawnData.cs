using System;
using NaughtyAttributes;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace _Project.Scripts.Data
{
    [Serializable]
    public class SpawnData
    {
        public EnemyUnitData EnemyUnitData;
        [MinMaxSlider(1, 15)]
        public Vector2Int Enemies;
        [MinMaxSlider(0.1f, 5.0f)]
        public Vector2 StartSpawnDelay;
        [MinMaxSlider(1.0f, 15.0f)]
        public Vector2 SpawnIntervalTime;
    }
}