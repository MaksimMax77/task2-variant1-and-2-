using Sources.Variant1;
using Sources.Variant3.InputControl;
using Sources.Variant3.ObjectPoolSpace;
using Sources.Variant3.PrefabsCreation;
using Sources.Variant3.SceneSibling;
using Sources.Variant3.Unit;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Sources.System.Installers
{
    public class SceneContextInstaller : MonoInstaller
    {
        [SerializeField] private Updater _updater;
        [SerializeField] private UnitCreation _unitCreation;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private ObjectPoolsManager _objectPoolsManager;
        public override void InstallBindings()
        {
            Container.Bind<RootObjectsCreator>().AsSingle().NonLazy();
            Container.BindInstance(_updater).AsSingle().NonLazy();
            Container.BindInstance(_unitCreation).AsSingle().NonLazy();
            Container.BindInstance(_input).AsSingle().NonLazy();
            Container.BindInstance(_objectPoolsManager).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MobileInputHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Unit>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ClickOnInteractiveObject>().AsSingle().NonLazy();
        }
    }
}