using UnityEngine;

namespace Sources.Variant3.Animations
{
    public class IkControl : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _ArmIk;
        private void OnAnimatorIK(int layerIndex)
        {
            if (!enabled)
            {
                return;
            }
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _ArmIk.position);
        }
    }
}
