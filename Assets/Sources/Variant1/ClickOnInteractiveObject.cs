using System;
using Sources.Variant3.InputControl;
using Sources.Variant3.PrefabsCreation;
using UnityEngine;
using Zenject;

namespace Sources.Variant1
{
    public class ClickOnInteractiveObject: IDisposable
    {
        private InputHandler _inputHandler;
        private Camera _camera;
    
        [Inject]
        public void Init(InputHandler inputHandler, UnitCreation unitCreation)
        {
            _inputHandler = inputHandler;
            _camera = unitCreation.CreatedCamera.Camera;
            _inputHandler.TouchPerformed += OnClick;
        }
    
        public void Dispose()
        {
            _inputHandler.TouchPerformed -= OnClick;
        }
    
        private void OnClick(Vector2 clickPos)
        {
            if (!Physics.Raycast(_camera.ScreenPointToRay(clickPos), out var hit, 100))
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
