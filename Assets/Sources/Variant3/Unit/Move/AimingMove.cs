using Sources.Variant3.Animations;
using UnityEngine;

namespace Sources.Variant3.Unit.Move
{
    public class AimingMove: BaseMove
    {
        public AimingMove(AnimatorControl animatorControl, Camera camera, Transform transform) : base(animatorControl, camera, transform)
        {
        }

        public override void UpdateMove(float hor, float vert, Vector2 rotation)
        {
            AnimateMove(hor, vert);
            Rotate(rotation);
        }

        private void Rotate(Vector2 rotateDir)
        {
            var angleA = 0f;

            if (Mathf.Atan2(-rotateDir.x, -rotateDir.y) * Mathf.Rad2Deg != 0)
            {
                angleA = Mathf.Atan2(-rotateDir.x, -rotateDir.y) * Mathf.Rad2Deg;
            }

            _transform.eulerAngles = new Vector3(0f, angleA + 90f, 0);
        }

        private void AnimateMove(float hor, float vert)
        {
            var dir = new Vector3(hor, 0, vert);
            dir.Normalize();
            var orientation = СalculateOrientation(dir.normalized, _transform.forward, _transform.right);
            _animatorControl.AnimateMoveForward(orientation.x);
            _animatorControl.AnimateMoveSide(orientation.z * -1);
        }

        private Vector3 СalculateOrientation(Vector3 lhs, Vector3 z, Vector3 x)
        {
            var floatZ = Vector3.Dot(lhs.normalized, z);
            var floatX = Vector3.Dot(lhs.normalized, x);

            return new Vector3(floatX, 0, floatZ);
        }
    }
}
