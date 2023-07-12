using Sources.Variant3.ObjectPoolSpace;
using UnityEngine;

namespace Sources.Variant3.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _cooldown;
        [SerializeField] private ObjectPoolType _poolType;
        [SerializeField] private Transform _projectilePos;
        [SerializeField] private GameObject _muzzle;
        private ObjectPool _pool;
        private Timer _timer;

        public void Attack()
        {
            _timer.UpdateTimer();
            
            if (_timer.available)
            {
                var createdObj = _pool.GetObject();
                createdObj.transform.position = _projectilePos.position;
                createdObj.transform.rotation = _projectilePos.rotation;
                createdObj.gameObject.SetActive(true);
                _timer.TimerZero();
            }
        }

        public void MuzzleEnable(bool value)
        {
            _muzzle.SetActive(value);
        }

        public void SetPool(ObjectPoolsManager objectPoolsManager)
        {
            _pool = objectPoolsManager.GetPoolByObjectPoolType(_poolType);
        }
        private void Awake()
        { 
            _timer = new Timer(_cooldown);
        }
    }
}
