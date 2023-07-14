using System;
using Sources.System;
using Sources.Variant3.ObjectPoolSpace;
using Sources.Variant3.PrefabsCreation;
using Sources.Variant3.Unit.Move;
using Sources.Variant3.Unit.Views;
using Sources.Variant3.WeaponSystem;
using UnityEngine.InputSystem;
using Zenject;

namespace Sources.Variant3.Unit
{
    public class Unit: IDisposable, IUpdate
    {
        private InputActions _input;

        private ShootingAnimate _shootingAnimate;
        private MoveAnimate _moveAnimate;

        private UnitFreeMove _unitFreeMove;
        private AimingMove _aimingMove;
        private BaseMove _baseMove;
        private WeaponControl _weaponControl;

        [Inject]
        public void Init(Updater updater, UnitCreation unitCreation, InputActions input, ObjectPoolsManager objectPoolsManager)
        {
            _input = input;
            updater.AddUpdate(this);
            
            _shootingAnimate = unitCreation.CreatedObject.GetComponent<ShootingAnimate>();
            _moveAnimate = unitCreation.CreatedObject.GetComponent<MoveAnimate>();
            var weaponsList = unitCreation.CreatedObject.GetComponent<WeaponList>();
            
            _unitFreeMove = new UnitFreeMove(unitCreation.CreatedCamera.Camera,  unitCreation.CreatedObject.transform, _moveAnimate);
            _aimingMove = new AimingMove(unitCreation.CreatedCamera.Camera,  unitCreation.CreatedObject.transform, _moveAnimate);
            _baseMove = _unitFreeMove;
            _weaponControl = new WeaponControl(weaponsList, objectPoolsManager);

            _input.Enable();
            
            MoveSubscribeOnInputActions();
            SubscribeOnFireInputActions();
            _input.Gamepad.Roll.performed +=  _moveAnimate.SetRollAnim;
            _input.Gamepad.NextWeapon.performed +=  _weaponControl.OnNextWeaponClick;
        }
        
        public void Dispose()
        {
            MoveUnSubscribeFromInputActions();
            UnSubscribeFromFireInputActions();
            
            _input.Gamepad.Roll.performed -=  _moveAnimate.SetRollAnim;
            _input.Gamepad.NextWeapon.performed -=  _weaponControl.OnNextWeaponClick;
            
            _input.Disable();
        }
        
        public void Update()
        {
            _baseMove.UpdateMove();
            _weaponControl.Update();
        }

        private void OnFireClick(InputAction.CallbackContext context)
        {
            SetMove(true);
        }
        
        private void OnFireCanceled(InputAction.CallbackContext context)
        {
            SetMove(false);
        }

        private void SetMove(bool value)
        {
            MoveUnSubscribeFromInputActions();

            _baseMove = value ? _aimingMove : _unitFreeMove;

            MoveSubscribeOnInputActions();
        }
        
        private void MoveSubscribeOnInputActions()
        {
            _input.Gamepad.Move.performed += _baseMove.OnMovePerformed;
            _input.Gamepad.Move.canceled += _baseMove.OnMovePerformed;
            
            _input.Gamepad.Rotation.performed += _baseMove.OnRotatePerformed;
            _input.Gamepad.Rotation.canceled += _baseMove.OnRotatePerformed;
        }
        
        private void MoveUnSubscribeFromInputActions()
        {
            _input.Gamepad.Move.performed += _baseMove.OnMovePerformed;
            _input.Gamepad.Move.canceled += _baseMove.OnMovePerformed;
            
            _input.Gamepad.Rotation.performed += _baseMove.OnRotatePerformed;
            _input.Gamepad.Rotation.canceled += _baseMove.OnRotatePerformed;
        }

        private void SubscribeOnFireInputActions()
        {
            _input.Gamepad.Fire.performed += _weaponControl.OnFirePerformed;
            _input.Gamepad.Fire.canceled += _weaponControl.OnFireCanceled;
            _input.Gamepad.Fire.performed += _shootingAnimate.OnFirePerformed;
            _input.Gamepad.Fire.canceled += _shootingAnimate.OnFireCanceled;
            _input.Gamepad.Fire.performed += OnFireClick;
            _input.Gamepad.Fire.canceled += OnFireCanceled;;
        }
        
        private void UnSubscribeFromFireInputActions()
        {
            _input.Gamepad.Fire.performed -= _weaponControl.OnFirePerformed;
            _input.Gamepad.Fire.canceled -= _weaponControl.OnFireCanceled;
            _input.Gamepad.Fire.performed -= _shootingAnimate.OnFirePerformed;
            _input.Gamepad.Fire.canceled -= _shootingAnimate.OnFireCanceled;
            _input.Gamepad.Fire.performed -= OnFireClick;
            _input.Gamepad.Fire.canceled -= OnFireCanceled;
        }
    } 
}
