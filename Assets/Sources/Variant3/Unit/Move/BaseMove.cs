using Sources.Variant3.Unit.Views;
using UnityEngine;

namespace Sources.Variant3.Unit.Move
{
    public abstract class BaseMove
    {
        protected Camera _camera;
        protected Transform _transform;
        protected MoveView _moveView;

        protected BaseMove(Camera camera, Transform transform, MoveView moveView)
        {
            _camera = camera;
            _transform = transform;
            _moveView = moveView;
        }
    
        public abstract void UpdateMove(float hor, float vert, Vector2 rotationDir);
    }
}
