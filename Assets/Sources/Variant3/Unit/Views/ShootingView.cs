using UnityEngine;

namespace Sources.Variant3.Unit.Views
{
    public class ShootingView : MonoBehaviour
    {
        [SerializeField] private string _shootTransitionName; 
        [SerializeField] private string _aimingName;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _effect;
        [SerializeField] private Transform _shootingPos;

        public Transform ShootingPos => _shootingPos;

        public void Visualize(bool value)
        {
            AimingPose(value);
            ShootingAnimation(value);
            _effect.SetActive(value);
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
