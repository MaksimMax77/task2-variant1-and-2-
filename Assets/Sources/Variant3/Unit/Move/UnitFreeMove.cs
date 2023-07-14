using Sources.Variant3.Unit.Views;
using UnityEngine;

namespace Sources.Variant3.Unit.Move
{
    public class UnitFreeMove: BaseMove
    {
        public UnitFreeMove( Camera camera, Transform transform, MoveAnimate moveAnimate) : 
            base(camera, transform, moveAnimate)
        {
        }
        public override void UpdateMove()
        {
            Move(_inputDir.x, _inputDir.y);
            RotationToMoveDirection(new Vector2(_inputDir.x, _inputDir.y));
        }
        private void Move(float inputX, float inputY)
        {
            if (inputX != 0 || inputY != 0)
            {
                MoveAnimate.AnimateMoveForward(1);
            }
            else
            {
                MoveAnimate.AnimateMoveForward(0);
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
