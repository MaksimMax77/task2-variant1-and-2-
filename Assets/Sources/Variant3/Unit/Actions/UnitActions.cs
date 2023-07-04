using Sources.Variant3.Animations;

namespace Sources.Variant3.Unit
{
    public class UnitActions
    {
        private AnimatorControl _animatorControl;
        public UnitActions(AnimatorControl animatorControl)
        {
            _animatorControl = animatorControl;
        }
        public void Fire(bool fire)
        {
            _animatorControl.SetAttackAnim(fire);
            _animatorControl.SetAiming(fire);
        }
        public void Roll()
        {
            _animatorControl.SetRollAnim();
        }
    }
}
