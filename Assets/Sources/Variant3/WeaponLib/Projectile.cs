using UnityEngine;

namespace Sources.Variant3.WeaponLib
{
     public class Projectile : MonoBehaviour
     {
          [SerializeField] private float _speed;
          [SerializeField] private float _destroyTime;
          private Timer _timer;

          private void Awake()
          {
               _timer = new Timer(_destroyTime);
          }

          private void Update()
          {
               transform.position += transform.forward * _speed * Time.deltaTime;
               _timer.UpdateTimer();
               
               if (!_timer.available)
               {
                   return;
               }
               Destroy(gameObject);
          }
     }
}
