using Sources.Variant3.Animations;
using UnityEngine;

namespace Sources.Variant3.Unit.Move
{
    public abstract class BaseMove
    {
        protected AnimatorControl _animatorControl;
        protected Camera _camera;
        protected Transform _transform;

        protected BaseMove(AnimatorControl animatorControl, Camera camera, Transform transform)
        {
            _animatorControl = animatorControl;
            _camera = camera;
            _transform = transform;
        }
    
        public abstract void UpdateMove(float hor, float vert, Vector2 rotationDir);
    }
}
