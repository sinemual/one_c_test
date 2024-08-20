using System.Collections.Generic;
using _Project.Scripts.Data;
using UnityEngine;

public class VfxFactory
{
    private readonly SharedData _sharedData;
    private readonly RuntimeData _runtimeData;
    
    private Dictionary<VfxType, GameObjectPool> _pools;

    private VfxFactory(SharedData sharedData, RuntimeData runtimeData)
    {
        _sharedData = sharedData;
        _runtimeData = runtimeData;
        _pools = new Dictionary<VfxType, GameObjectPool>();
    }

    public void Create(VfxType vfxType, Vector2 position)
    {
        if (!_pools.ContainsKey(vfxType))
            _pools.Add(vfxType, new GameObjectPool(_sharedData.VfxByType[vfxType].gameObject, _sharedData.PrewarmVfxsAmount, _runtimeData.CurrentLevel.View.transform));
        
        var vfxGo = _pools[vfxType].GetObjectFromPool();
        _pools[vfxType].JustPoolObject(vfxGo);
        vfxGo.GetComponent<ParticleSystem>().Play();
        vfxGo.transform.position = position;
    }
}