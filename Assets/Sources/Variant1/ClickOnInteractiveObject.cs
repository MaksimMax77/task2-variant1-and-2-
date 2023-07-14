using System;
using Sources.Variant3.PrefabsCreation;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Sources.Variant1
{
    public class ClickOnInteractiveObject: IDisposable
    {
        private Camera _camera;
        private InputActions _inputActions;
    
        [Inject]
        public void Init(InputActions inputActions, UnitCreation unitCreation)
        {
            _inputActions = inputActions;
            _camera = unitCreation.CreatedCamera.Camera;
            _inputActions.Gamepad.Tap.performed += OnClick;
        }
    
        public void Dispose()
        {
            _inputActions.Gamepad.Tap.performed -= OnClick;
        }
    
        private void OnClick(InputAction.CallbackContext context)
        {
            if (!Physics.Raycast(_camera.ScreenPointToRay(context.ReadValue<Vector2>()), out var hit, 100))
            {
                return;
            }

            var clickableObj = (IClickable) hit.collider.GetComponent(typeof(IClickable));
            if (clickableObj == null)
            {
                return;
            }

            clickableObj.Click();
        }
    }
}
