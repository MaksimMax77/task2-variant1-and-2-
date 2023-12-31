using Sources.Variant3.Unit.Views;
using UnityEngine;

namespace Sources.Variant3.Unit.Move
{
    public class AimingMove: BaseMove
    {
        public AimingMove(Camera camera, Transform transform, MoveAnimate moveAnimate) : 
            base(camera, transform, moveAnimate)
        {
        }

        public override void UpdateMove()
        {
            AnimateMove(_inputDir.x, _inputDir.z);
            Rotate(_rotateDir);
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
            MoveAnimate.AnimateMoveForward(orientation.x);
            MoveAnimate.AnimateMoveSide(orientation.z * -1);
        }

        private Vector3 СalculateOrientation(Vector3 lhs, Vector3 z, Vector3 x)
        {
            var floatZ = Vector3.Dot(lhs.normalized, z);
            var floatX = Vector3.Dot(lhs.normalized, x);

            return new Vector3(floatX, 0, floatZ);
        }
    }
}
