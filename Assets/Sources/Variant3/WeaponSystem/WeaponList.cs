using System.Collections.Generic;
using Sources.Variant3.ObjectPoolSpace;
using UnityEngine;

namespace Sources.Variant3.WeaponSystem
{
    public class WeaponList : MonoBehaviour
    {
        [SerializeField] private Weapon[] _weaponPrefabs;
        [SerializeField] private Transform _weaponParent;
        [SerializeField] private Transform _weaponTransorm; 
        [SerializeField] private int _currentWeaponIndex;
        private List<Weapon> _weapons = new List<Weapon>();

        public void Init(ObjectPoolsManager objectPoolsManager)
        {
            for (int i = 0, len = _weaponPrefabs.Length; i < len; ++i)
            {
                var obj = Instantiate(_weaponPrefabs[i],_weaponParent);
                obj.transform.position = _weaponTransorm.position;
                obj.transform.rotation = _weaponTransorm.rotation;
                obj.gameObject.SetActive(false);
                obj.SetPool(objectPoolsManager);
                _weapons.Add(obj);
            }
        }
        
        public Weapon GetCurrentWeapon(bool value = true)
        {
            var weapon = _weapons[_currentWeaponIndex];
            weapon.gameObject.SetActive(value);
            return weapon;
        }

        public Weapon NextWeapon()
        {
            GetCurrentWeapon(false);
            
            ++_currentWeaponIndex;
            if (_currentWeaponIndex >= _weapons.Count)
            {
                _currentWeaponIndex = 0;
            }
            return GetCurrentWeapon();
        }
    }
}
