using System;
using Sources.System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Sources.Variant3.InputControl
{
    public class MobileInputHandler: IUpdate, IDisposable
    {
        public event Action<Vector2> MovePerformed;
        public event Action<bool> FirePerformed;
        public event Action<Vector2> RotationPerformed;
        public event Action RollPerformed;
        public event Action<Vector2> TouchPerformed; 
        private const string _moveActionName = "Move";
        private const string _fireActionName = "Fire";
        private const string _rotationActionName = "Rotation";
        private const string _rollActionName = "Roll";
        private const string _tapName = "Tap";
        private PlayerInput _playerInput;

        [Inject]
        public void Init(Updater updater, PlayerInput input)
        {
            updater.AddUpdate(this);
            _playerInput = input;
            _playerInput.actions[_moveActionName].performed += OnMovePerformed;
            _playerInput.actions[_moveActionName].canceled += OnMovePerformed;
            
            _playerInput.actions[_fireActionName].performed += OnFirePerformed;
            _playerInput.actions[_fireActionName].canceled += OnFireCanceled;
            
            _playerInput.actions[_rotationActionName].performed += OnRotationPerformed;
            _playerInput.actions[_rotationActionName].canceled += OnRotationPerformed;
            
            _playerInput.actions[_rollActionName].performed += OnRollPerformed;
            
            _playerInput.actions[_tapName].performed += OnTapPerformed;
        }
        
        public void Dispose()
        {
            _playerInput.actions[_moveActionName].performed -= OnMovePerformed;
            _playerInput.actions[_moveActionName].canceled -= OnMovePerformed;
            
            _playerInput.actions[_fireActionName].performed -= OnFirePerformed;
            _playerInput.actions[_fireActionName].canceled -= OnFireCanceled;
            
            _playerInput.actions[_rotationActionName].performed -= OnRotationPerformed;
            _playerInput.actions[_rotationActionName].canceled -= OnRotationPerformed;
            
            _playerInput.actions[_rollActionName].performed -= OnRollPerformed;
            _playerInput.actions[_tapName].performed -= OnTapPerformed;
        }
        public void Update()
        {
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            MovePerformed?.Invoke( context.ReadValue<Vector2>());
        }

        private void OnFirePerformed(InputAction.CallbackContext context)
        {
            FirePerformed?.Invoke(true);
        }
        
        private void OnFireCanceled(InputAction.CallbackContext context)
        {
            FirePerformed?.Invoke(false);
        }

        private void OnRotationPerformed(InputAction.CallbackContext context)
        {
            RotationPerformed?.Invoke(context.ReadValue<Vector2>());
        }

        private void OnRollPerformed(InputAction.CallbackContext context)
        {
            RollPerformed?.Invoke();
        }

        private void OnTapPerformed(InputAction.CallbackContext context)
        {
            TouchPerformed?.Invoke( context.ReadValue<Vector2>());
        }
    }
}
