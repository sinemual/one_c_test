using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Enemy
{
    public class LinearEnemyBehaviour : EnemyBehaviour
    {
        public override void StartMove(Transform transform, float speed, Vector2 endPoint)
        {
            transform.DOMove(endPoint, 10 / speed).OnComplete(InvokePlayerDamaged).SetEase(Ease.Linear);
        }
        
        public override void StopMove(Transform transform)
        {
            transform.DOKill();
        }
    }
}