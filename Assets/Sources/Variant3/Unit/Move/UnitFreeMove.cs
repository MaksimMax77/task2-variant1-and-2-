using Sources.Variant3.Animations;
using UnityEngine;

namespace Sources.Variant3.Unit.Move
{
    public class UnitFreeMove: BaseMove
    {
        public UnitFreeMove(AnimatorControl animatorControl, Camera camera, Transform transform) : base(animatorControl, camera, transform)
        {
        }
        public override void UpdateMove(float hor, float vert, Vector2 rotationDir)
        {
            Move(hor, vert);
            RotationToMoveDirection(new Vector2(hor, vert));
        }
        private void Move(float inputX, float inputY)
        {
            if (inputX != 0 || inputY != 0)
            {
                _animatorControl.AnimateMoveForward(1);
            }
            else
            {
                _animatorControl.AnimateMoveForward(0);
            }
        }
        private void RotationToMoveDirection(Vector2 rotateDir)
        {
            var dir = DirectionRelativeCamera(rotateDir);
            var newDirection = Vector3.RotateTowards(_transform.forward, dir, 10 * Time.deltaTime, 0.0f);
            _transform.rotation = Quaternion.LookRotation(newDirection);
        }
        
        private Vector3 DirectionRelativeCamera(Vector3 dir)
        {
            
            dir = _camera.transform.TransformDirection(dir);

            return new Vector3(dir.x, 0, dir.z);
        }
    }
}
