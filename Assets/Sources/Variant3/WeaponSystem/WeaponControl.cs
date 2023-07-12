using Sources.Variant3.ObjectPoolSpace;

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
        
        public void OnFirePerformed(bool attack)
        {
            _fire = attack;
        }

        public void OnNextWeaponClick()
        {
            _currentWeapon = _weaponList.NextWeapon();
        }
    }
}
