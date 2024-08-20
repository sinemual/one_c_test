using System;
using _Project.Scripts.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class ShootSystem
{
    protected WeaponData _weaponData;
    protected Transform _shootPoint;
    protected bool isReload;
    protected Transform _target;

    protected readonly GameObjectPool _projectilesPool;

    protected ShootSystem(WeaponData weaponData, Transform shootPoint)
    {
        _weaponData = weaponData;
        _shootPoint = shootPoint;
        _projectilesPool = new GameObjectPool(weaponData.ProjectilePrefab, 3);
    }

    public void SetWeapon(WeaponData weaponData, Transform shootPoint)
    {
        _weaponData = weaponData;
        _shootPoint = shootPoint;
    }
    
    public void CleanProjectilesPool() => _projectilesPool.DeletePool();

    public abstract bool TryShoot(Transform target);

    protected async UniTask Reload()
    {
        isReload = true;
        await UniTask.Delay(TimeSpan.FromSeconds(_weaponData.ReloadTime), ignoreTimeScale: false);
        isReload = false;
        if (_target && _target.gameObject.activeInHierarchy)
            TryShoot(_target);
    }

    protected GameObject GetProjectile() => _projectilesPool.GetObjectFromPool();
}