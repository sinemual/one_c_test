using _Project.Scripts.Data;
using UnityEngine;

public class PhysicShootSystem : ShootSystem
{
    public override bool TryShoot(Transform target)
    {
        _target = target;
        
        if (!_target)
            return false;
        
        if (isReload)
            return false;
        
        var projectileGo = GetProjectile();
        projectileGo.transform.SetPositionAndRotation(_shootPoint.position, _shootPoint.rotation);
        
        var projectile = projectileGo.GetComponent<Projectile>();
        projectile.InitDamage(_weaponData.Damage);
        projectile.Hit += () => _projectilesPool.PoolObjectAndPrepare(projectileGo);
        var projectileRb = projectileGo.GetComponent<Rigidbody2D>();
        projectileRb.velocity = Vector3.zero;
        var direction = _target.position - _shootPoint.position;

        projectileRb.AddForce(direction * _weaponData.BulletSpeed);
        
        Reload();
        return true;
    }

    public PhysicShootSystem(WeaponData weaponData, Transform shootPoint) : base(weaponData, shootPoint)
    {
    }
}