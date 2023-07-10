using System;
using Sources.System;
using Sources.Variant3.InputControl;
using Sources.Variant3.PrefabsCreation;
using Sources.Variant3.Unit.Move;
using Sources.Variant3.Unit.Views;
using Sources.Variant3.WeaponLib;
using UnityEngine;
using Zenject;

namespace Sources.Variant3.Unit
{
    public class Unit: IDisposable, IUpdate
    {
        private MobileInputHandler _inputHandler;

        private ShootingView _shootingView;
        private MoveView _moveView;

        private UnitFreeMove _unitFreeMove;
        private AimingMove _aimingMove;
        private BaseMove _baseMove;
        private Shooting _shooting;
        private Vector3 _inputDir;
        private Vector2 _rotationDir;

        [Inject]
        public void Init(Updater updater, UnitCreation unitCreation, MobileInputHandler inputHandler, WeaponsList weaponsList)
        {
            _inputHandler = inputHandler;
            updater.AddUpdate(this);
            
            _shootingView = unitCreation.CreatedObject.GetComponent<ShootingView>();
            _moveView = unitCreation.CreatedObject.GetComponent<MoveView>();
            
            _unitFreeMove = new UnitFreeMove(unitCreation.CreatedCamera.Camera,  unitCreation.CreatedObject.transform, _moveView);
            _aimingMove = new AimingMove(unitCreation.CreatedCamera.Camera,  unitCreation.CreatedObject.transform, _moveView);
            _baseMove = _unitFreeMove;
            _shooting = new Shooting(weaponsList, _shootingView.ShootingPos);
            
            _inputHandler.MovePerformed += OnMoveInput;
            _inputHandler.RotationPerformed += OnRotationPerformed;
            _inputHandler.FirePerformed += OnFireClick;
            _inputHandler.FirePerformed += _shootingView.Visualize;
            _inputHandler.RollPerformed += _moveView.SetRollAnim;
            _inputHandler.FirePerformed += _shooting.OnFirePerformed;
        }

        public void Dispose()
        {
            _inputHandler.MovePerformed -= OnMoveInput;
            _inputHandler.RotationPerformed -= OnRotationPerformed;
            _inputHandler.FirePerformed -= OnFireClick;
            _inputHandler.FirePerformed -= _shootingView.Visualize;
            _inputHandler.RollPerformed -= _moveView.SetRollAnim;
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
