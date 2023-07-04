using UnityEngine;

namespace Sources.Variant3.Animations
{
    public class AnimatorControl : MonoBehaviour
    {
        [SerializeField] private string _moveForwardTagName;
        [SerializeField] private string _moveSideTagName;
        [SerializeField] private string _aimingTagName;
        [SerializeField] private string _attackTagName;
        [SerializeField] private string _rollTagName;
        [SerializeField] private Animator _animator;
        
        public void AnimateMoveForward(float value)
        {
            _animator.SetFloat(_moveForwardTagName, value);
        }
        public void AnimateMoveSide(float value)
        {
            _animator.SetFloat(_moveSideTagName, value);
        }
        public void SetAiming(bool value)
        {
            _animator.SetBool(_aimingTagName, value);
        }
        
        public void SetAttackAnim(bool value)
        {
            if (value)
            {
                _animator.SetTrigger(_attackTagName);
            }
            else
            {
                _animator.ResetTrigger(_attackTagName);
            }
        }
        
        public void SetRollAnim()
        {
            _animator.SetTrigger(_rollTagName);
        }
    }
}
