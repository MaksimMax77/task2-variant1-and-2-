using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Variant3.Unit.Views
{
    public class ShootingAnimate : MonoBehaviour
    {
        [SerializeField] private string _shootTransitionName; 
        [SerializeField] private string _aimingName;
        [SerializeField] private Animator _animator;

        public void OnFirePerformed(InputAction.CallbackContext context)
        {
            Animate(true);
        }
        
        public void OnFireCanceled(InputAction.CallbackContext context)
        {
            Animate(false);
        }
        
        private void Animate(bool value)
        {
            AimingPose(value);
            ShootingAnimation(value);
        }
        private void ShootingAnimation(bool value)
        {
            _animator.SetBool(_shootTransitionName, value);
        }
    
        private void AimingPose(bool value)
        {
            _animator.SetBool(_aimingName, value);
        }
    }
}
