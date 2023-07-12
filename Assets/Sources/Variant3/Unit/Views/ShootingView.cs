using UnityEngine;

namespace Sources.Variant3.Unit.Views
{
    public class ShootingView : MonoBehaviour
    {
        [SerializeField] private string _shootTransitionName; 
        [SerializeField] private string _aimingName;
        [SerializeField] private Animator _animator;

        public void Animate(bool value)
        {
            AimingPose(value);
            ShootingAnimation(value);
        }

        private void ShootingAnimation(bool value)
        {
            if (value)
            {
                _animator.SetTrigger(_shootTransitionName);
            }
            else
            {
                _animator.ResetTrigger(_shootTransitionName);
            }
        }
    
        private void AimingPose(bool value)
        {
            _animator.SetBool(_aimingName, value);
        }
    
    }
}
