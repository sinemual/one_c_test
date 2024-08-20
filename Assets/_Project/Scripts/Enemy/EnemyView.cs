using UnityEngine;

namespace _Project.Scripts.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        public EnemyUnit UnitData => _unitData;
        
        private EnemyUnit _unitData;

        public void Init(EnemyUnit unitData)
        {
            _unitData = unitData;
        }
    }
}