using Sources.Variant3.ObjectPoolSpace;
using UnityEngine;

namespace Sources.Variant3.WeaponLib
{
    public class Shooting
    {
        private Projectile _projectie;
        private Transform _shootTransform;
        private float _cooldown;
        private WeaponsList _weaponsList;
        private Timer _timer;
        private bool _fire;
        private ObjectPool _objectPool;
        

        public Shooting(WeaponsList settings, Transform shootTransform, ObjectPoolsManager objectPoolsManager)
        {
            _objectPool = objectPoolsManager.GetPoolByObjectPoolType(ObjectPoolType.standardBulletsPool);
            _weaponsList = settings;
            SetWeapon();
            _timer = new Timer(_cooldown);
            _shootTransform =  shootTransform;
        }

        public void SetWeapon(int index = 0)
        {
            var containers = _weaponsList.WeaponContainers;
            _projectie = containers[index].projectile;
            _cooldown = containers[index].cooldown;
        }
        
        public void Update()
        {
            if (!_fire)
            {
                return;
            }
            _timer.UpdateTimer();
            
            if (_timer.available)
            {
                var createdObj = _objectPool.GetObject();
                createdObj.transform.position = _shootTransform.position;
                createdObj.transform.rotation = _shootTransform.rotation;
                createdObj.gameObject.SetActive(true);
                /*Object.Instantiate(_projectie, _shootTransform.position, _shootTransform.rotation);*/
                _timer.TimerZero();
            }
        }

        public void OnFirePerformed(bool attack)
        {
            _fire = attack;
        }
    }
}
