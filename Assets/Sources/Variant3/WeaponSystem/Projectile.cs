using Sources.Variant3.ObjectPoolSpace;
using UnityEngine;

namespace Sources.Variant3.WeaponSystem
{
     public class Projectile : MonoBehaviour
     {
          [SerializeField] private float _speed;
          [SerializeField] private float _destroyTime;
          [SerializeField] private PooledObject _pooledObject;
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
               _pooledObject.ReturnObjectToPool();
          }

          private void OnDisable()
          {
               _timer.TimerZero();
          }
     }
}
