using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Sources.Variant3.InputControl
{
    public class InputHandler: IDisposable
    {
        public event Action<Vector2> MovePerformed;
        public event Action<bool> FirePerformed;
        public event Action<Vector2> RotationPerformed;
        public event Action RollPerformed;
        public event Action<Vector2> TouchPerformed;
        public event Action NextWeaponPerformed;

        private InputActions _input;

        [Inject]
        public void Init(InputActions input)
        {
            _input = input;
            _input.Enable();

            _input.Gamepad.Move.performed += OnMovePerformed;
            _input.Gamepad.Move.canceled += OnMovePerformed;

            _input.Gamepad.Fire.performed += OnFirePerformed;
            _input.Gamepad.Fire.canceled += OnFireCanceled;
            
            _input.Gamepad.Rotation.performed += OnRotationPerformed;
            _input.Gamepad.Rotation.canceled += OnRotationPerformed;
            
            _input.Gamepad.Roll.performed += OnRollPerformed;
            _input.Gamepad.Tap.performed += OnTapPerformed;
            
            _input.Gamepad.NextWeapon.performed += OnNextWeaponPerformed;
        }
        
        public void Dispose()
        {
            _input.Gamepad.Move.performed += OnMovePerformed;
            _input.Gamepad.Move.canceled += OnMovePerformed;

            _input.Gamepad.Fire.performed += OnFirePerformed;
            _input.Gamepad.Fire.canceled += OnFireCanceled;
            
            _input.Gamepad.Rotation.performed += OnRotationPerformed;
            _input.Gamepad.Rotation.canceled += OnRotationPerformed;
            
            _input.Gamepad.Roll.performed += OnRollPerformed;
            _input.Gamepad.Tap.performed += OnTapPerformed;
            
            _input.Gamepad.NextWeapon.performed += OnNextWeaponPerformed;
            
            _input.Disable();
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

        private void OnNextWeaponPerformed(InputAction.CallbackContext context)
        {
            NextWeaponPerformed?.Invoke();
        }
    }
}
