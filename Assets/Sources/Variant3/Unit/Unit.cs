using System;
using Sources.System;
using Sources.Variant3.Animations;
using Sources.Variant3.InputControl;
using Sources.Variant3.PrefabsCreation;
using Sources.Variant3.Unit.Move;
using Sources.Variant3.WeaponLib;
using UnityEngine;
using Zenject;

namespace Sources.Variant3.Unit
{
    public class Unit: IDisposable, IUpdate
    {
        private MobileInputHandler _inputHandler;
        private AnimatorControl _animatorControl;

        private UnitFreeMove _unitFreeMove;
        private AimingMove _aimingMove;
        private BaseMove _baseMove;
        private UnitActions _unitActions;
        private Shooting _shooting;
        private Vector3 _inputDir;
        private Vector2 _rotationDir;
        private WeaponsList _weaponsList;

        [Inject]
        public void Init(Updater updater, UnitCreation unitCreation, MobileInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            updater.AddUpdate(this);
            
            _animatorControl = unitCreation.CreatedObject.GetComponent<AnimatorControl>();
            _weaponsList = unitCreation.CreatedObject.GetComponent<WeaponsList>();
            _unitFreeMove = new UnitFreeMove(_animatorControl, unitCreation.CreatedCamera.Camera,  unitCreation.CreatedObject.transform);
            _aimingMove = new AimingMove(_animatorControl, unitCreation.CreatedCamera.Camera,  unitCreation.CreatedObject.transform);
            _baseMove = _unitFreeMove;
            _unitActions = new UnitActions(_animatorControl);
            _shooting = new Shooting(_weaponsList);
            _inputHandler.MovePerformed += OnMoveInput;
            _inputHandler.RotationPerformed += OnRotationPerformed;
            _inputHandler.FirePerformed += OnFireClick;
            _inputHandler.FirePerformed += _unitActions.Fire;
            _inputHandler.RollPerformed += _unitActions.Roll;
            _inputHandler.FirePerformed += _shooting.OnFirePerformed;

        }

        public void Dispose()
        {
            _inputHandler.MovePerformed -= OnMoveInput;
            _inputHandler.RotationPerformed -= OnRotationPerformed;
            _inputHandler.FirePerformed -= OnFireClick;
            _inputHandler.FirePerformed -= _unitActions.Fire;
            _inputHandler.RollPerformed -= _unitActions.Roll;
            _inputHandler.FirePerformed -= _shooting.OnFirePerformed;
        }
        
        public void Update()
        {
            _baseMove.UpdateMove(_inputDir.x, _inputDir.y, _rotationDir);
            _shooting.Update();
        }

        private void OnMoveInput(Vector2 inputDir)
        {
            _inputDir =inputDir;
        }

        private void OnRotationPerformed(Vector2 rotationDir)
        {
            _rotationDir = rotationDir;
        }
        
        private void OnFireClick(bool fire)
        {
            _baseMove = fire ? _aimingMove : _unitFreeMove;
        }
    }
}
