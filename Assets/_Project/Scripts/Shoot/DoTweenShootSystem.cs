using _Project.Scripts.Data;
using DG.Tweening;
using UnityEngine;

public class DoTweenShootSystem : ShootSystem
{
    public override bool TryShoot(Transform target)
    {
        _target = target;
        
        if (isReload)
            return false;
        
        var projectileGo = GetProjectile();
        projectileGo.transform.SetPositionAndRotation(_shootPoint.position, _shootPoint.rotation);
        
        var projectile = projectileGo.GetComponent<Projectile>();
        projectile.InitDamage(_weaponData.Damage);

        projectileGo.transform.DOMove(target.position, 10 / _weaponData.BulletSpeed).SetEase(Ease.Linear);
        projectileGo.transform.DOLookAt(target.position, _weaponData.BulletSpeed).SetEase(Ease.Linear);
        
        Reload();
        return true;
    }

    public DoTweenShootSystem(WeaponData weaponData, Transform shootPoint) : base(weaponData, shootPoint)
    {
    }
}