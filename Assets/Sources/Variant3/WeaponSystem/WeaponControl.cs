using Sources.Variant3.ObjectPoolSpace;
using UnityEngine.InputSystem;

namespace Sources.Variant3.WeaponSystem
{
    public class WeaponControl
    {
        private WeaponList _weaponList;
        private Weapon _currentWeapon;
        private bool _fire;

        public WeaponControl( WeaponList weaponList, ObjectPoolsManager objectPoolsManager)
        {
            _weaponList = weaponList;
            weaponList.Init(objectPoolsManager);
            _currentWeapon = _weaponList.GetCurrentWeapon();
        }
        
        public void Update()
        {
            _currentWeapon.MuzzleEnable(_fire);
            if (!_fire)
            {
                return;
            }
            _currentWeapon.Attack();
        }
        
        public void OnFirePerformed(InputAction.CallbackContext context)
        {
            _fire = true;
        }

        public void OnFireCanceled(InputAction.CallbackContext context)
        {
            _fire = false;
        }

        public void OnNextWeaponClick(InputAction.CallbackContext context)
        {
            _currentWeapon = _weaponList.NextWeapon();
        }
    }
}
