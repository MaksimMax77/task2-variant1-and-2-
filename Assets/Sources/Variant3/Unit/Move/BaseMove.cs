using Sources.Variant3.Unit.Views;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sources.Variant3.Unit.Move
{
    public abstract class BaseMove
    {
        protected Camera _camera;
        protected Transform _transform;
        protected MoveAnimate MoveAnimate;
        protected Vector3 _inputDir;
        protected Vector2 _rotateDir;
        protected BaseMove(Camera camera, Transform transform, MoveAnimate moveAnimate)
        {
            _camera = camera;
            _transform = transform;
            MoveAnimate = moveAnimate;
        }
    
        public abstract void UpdateMove();
        
        public void OnMovePerformed(InputAction.CallbackContext context)
        {
            _inputDir = context.ReadValue<Vector2>();
        }
        public void OnRotatePerformed(InputAction.CallbackContext context)
        {
            _rotateDir = context.ReadValue<Vector2>();
        }
    }
}
