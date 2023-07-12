using System;
using System.Collections.Generic;
using Sources.Variant3.SceneSibling;
using UnityEngine;
using Zenject;

namespace Sources.Variant3.ObjectPoolSpace
{
    public class ObjectPoolsManager : MonoBehaviour
    {
        [SerializeField] private List<ObjectPoolContainer> _containers = new List<ObjectPoolContainer>();

        [Inject]
        public void Init(RootObjectsCreator rootObjectsCreator)
        {
            var root = rootObjectsCreator.AddNewObjectToRoot(nameof(ObjectPoolsManager));
            
            for (int i = 0, len = _containers.Count; i < len; ++i)
            {
                var poolRoot = rootObjectsCreator.CreateGameObjectWithChild(_containers[i].PoolName, "disabled", "enabled");
                poolRoot.transform.SetParent(root.transform);
                
                _containers[i].Init( poolRoot.transform.GetChild(0).transform, poolRoot.transform.GetChild(1).transform);
            }
        }
        public ObjectPool GetPoolByObjectPoolType(ObjectPoolType objectPoolType)
        {
            for (int i = 0, len = _containers.Count; i < len; ++i)
            {
                if (_containers[i].ObjectPoolType == objectPoolType)
                {
                    return _containers[i].ObjectPool;
                }
            }
            return null;
        }
        
        [Serializable]
        public class ObjectPoolContainer
        {
            public PooledObject prefab;

            [SerializeField] 
            private ObjectPoolType _objectPoolType;

            [SerializeField] 
            private int _defaultPoolSize;

            [SerializeField]
            private string _poolName;

            private ObjectPool _objectPool;
            public ObjectPool ObjectPool => _objectPool;
            public string PoolName => _poolName;
            public ObjectPoolType ObjectPoolType => _objectPoolType;
            public void Init(Transform pooled, Transform enabled)
            {
                _objectPool = new ObjectPool(pooled, enabled, prefab, _defaultPoolSize);
            }
        }
    }
}
