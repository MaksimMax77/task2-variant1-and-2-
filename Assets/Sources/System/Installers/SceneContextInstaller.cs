using Sources.Variant1;
using Sources.Variant3.InputControl;
using Sources.Variant3.ObjectPoolSpace;
using Sources.Variant3.PrefabsCreation;
using Sources.Variant3.SceneSibling;
using Sources.Variant3.Unit;
using UnityEngine;
using Zenject;

namespace Sources.System.Installers
{
    public class SceneContextInstaller : MonoInstaller
    {
        [SerializeField] private Updater _updater;
        [SerializeField] private UnitCreation _unitCreation;
        [SerializeField] private ObjectPoolsManager _objectPoolsManager;
        private InputActions _inputActions;
        public override void InstallBindings()
        {
            Container.Bind<RootObjectsCreator>().AsSingle().NonLazy();
            Container.BindInstance(_updater).AsSingle().NonLazy();
            Container.BindInstance(_unitCreation).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputActions>().AsSingle().NonLazy();
            Container.BindInstance(_objectPoolsManager).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Unit>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ClickOnInteractiveObject>().AsSingle().NonLazy();
        }
    }
}