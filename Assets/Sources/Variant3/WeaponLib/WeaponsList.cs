using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Variant3.WeaponLib
{
   public class WeaponsList : MonoBehaviour
   {
      [SerializeField] private List<WeaponContainer> _weaponsContainers;
      public List<WeaponContainer> WeaponContainers => _weaponsContainers;

      [Serializable]
      public class WeaponContainer
      {
         public Projectile projectile;
         public float cooldown;
         public Transform shootPos;
      }
   }
}
