using UnityEngine;

namespace Sources.Variant3.Unit.Views
{
    public class MoveView : MonoBehaviour
    {
        [SerializeField] private string _moveForwardTag;
        [SerializeField] private string _moveSideTag;
        [SerializeField] private string _rollTag;
        [SerializeField] private Animator _animator;
    
        public void AnimateMoveForward(float value)
        {
            _animator.SetFloat(_moveForwardTag, value);
        }
    
        public void AnimateMoveSide(float value)
        {
            _animator.SetFloat(_moveSideTag, value);
        }
    
        public void SetRollAnim()
        {
            _animator.SetTrigger(_rollTag);
        }
    }
}
