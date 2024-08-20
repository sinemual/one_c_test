using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameObjectPool
{
    private List<GameObject> _pool;
    private GameObject _prefab;
    private Transform _parent;

    public GameObjectPool(GameObject prefab, int prewarmAmount = 1, Transform parent = null)
    {
        _pool = new List<GameObject>();
        _prefab = prefab;
        _parent = parent;
        if (!_parent)
            _parent = new GameObject($"Pool:{prefab}").transform;
        for (int i = 0; i < prewarmAmount; i++)
        {
            GameObject createdGo = Object.Instantiate(_prefab, _parent);
            createdGo.SetActive(false);
            _pool.Add(createdGo);
        }
    }

    public void PoolObjectAndPrepare(GameObject go)
    {
        go.transform.DOKill();
        go.SetActive(false);
        go.transform.position = Vector3.zero;
        _pool.Add(go);
    }

    public void JustPoolObject(GameObject go) => _pool.Add(go);

    public void DeletePool()
    {
        if (_parent)
            Object.Destroy(_parent.gameObject);
    }

    public GameObject GetObjectFromPool()
    {
        foreach (var go in _pool)
            if (go && !go.activeInHierarchy)
            {
                _pool.Remove(go);
                go.gameObject.SetActive(true);
                return go;
            }

        GameObject createdGo = Object.Instantiate(_prefab, _parent);
        createdGo.SetActive(false);
        _pool.Add(createdGo);

        return createdGo;
    }
}