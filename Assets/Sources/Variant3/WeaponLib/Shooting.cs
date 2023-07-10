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
        

        public Shooting(WeaponsList settings, Transform shootTransform)
        {
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
                Object.Instantiate(_projectie, _shootTransform.position, _shootTransform.rotation);
                _timer.TimerZero();
            }
        }

        public void OnFirePerformed(bool attack)
        {
            _fire = attack;
        }
    }
}
