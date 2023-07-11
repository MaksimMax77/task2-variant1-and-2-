using System.Collections.Generic;
using UnityEngine;

namespace Sources.Variant3.ObjectPoolSpace
{
    public class ObjectPool
    {
        private List<PooledObject> _pooledObjects = new();
        private List<PooledObject> _enabledObjects = new();
        private PooledObject _prefab;
        
        private Transform _pooledObjectsParent;
        private Transform _enabledObjectsParent;
        
        public ObjectPool(Transform pooledObjectsParent, Transform enabledObjectsParent, PooledObject prefab , int amount = 10)
        {
            _prefab = prefab;
            _pooledObjectsParent = pooledObjectsParent;
            _enabledObjectsParent = enabledObjectsParent;

            PreInstantiate(amount);
        }

        private void PreInstantiate(int amount)
        {
            for (var i = 0; i < amount; ++i)
            {
                var obj = CreateAndSetObj(_prefab, _pooledObjectsParent);
                obj.gameObject.SetActive(false);
                _pooledObjects.Add(obj);
            }
        }
        
        public Component GetObject()
        {
            if (_pooledObjects.Count == 0)
            {

                var newObj= CreateAndSetObj(_prefab, _enabledObjectsParent);
                _enabledObjects.Add(newObj);
                return newObj;
            }

            var obj = _pooledObjects[0];
            _enabledObjects.Add(obj);
            _pooledObjects.Remove(obj);
            obj.transform.SetParent(_enabledObjectsParent);
            return obj;
        }
        
        public void ReturnObjectToPool(PooledObject obj)
        {
            if (!_enabledObjects.Contains(obj))
            {
                return;
            }
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_pooledObjectsParent);
            _enabledObjects.Remove(obj);
            _pooledObjects.Add(obj);
        }

        private PooledObject CreateAndSetObj(PooledObject prefab, Transform parent)
        {
            var newObj = Object.Instantiate(prefab, parent, true);
            newObj.SetObjectPool(this);
            return newObj;
        }
    }
}
