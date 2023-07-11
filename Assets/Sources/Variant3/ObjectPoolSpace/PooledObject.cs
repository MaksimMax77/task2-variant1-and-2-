using UnityEngine;

namespace Sources.Variant3.ObjectPoolSpace
{
    public class PooledObject: MonoBehaviour
    { 
        private ObjectPool _objectPool;
        
        public ObjectPool ObjectPool=> _objectPool;

        public void SetObjectPool(ObjectPool objectPool)
        {
            _objectPool = objectPool;
        }

        public void ReturnObjectToPool()
        {
            _objectPool.ReturnObjectToPool(this);
        }
    }
}
