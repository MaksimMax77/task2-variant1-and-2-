using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sources.Variant3.ObjectPoolSpace
{
    public class ObjectPoolsManager : MonoBehaviour
    {
        [SerializeField] private List<ObjectPoolContainer> _containers = new List<ObjectPoolContainer>();

        [SerializeField] private Transform _disabledObjectsParent;
        [SerializeField] private Transform _enabledObjectsParent;

        [Inject]
        public void Init()
        {
            for (int i = 0, len = _containers.Count; i < len; ++i)
            {
                _containers[i].Init(_disabledObjectsParent, _enabledObjectsParent);
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
            public ObjectPoolType ObjectPoolType => _objectPoolType;
            public void Init(Transform pooled, Transform enabled)
            {
                _objectPool = new ObjectPool(pooled, enabled, prefab, _defaultPoolSize);
            }
        }
    }
}
