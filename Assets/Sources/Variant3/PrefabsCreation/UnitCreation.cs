using Sources.Variant3.SceneSibling;
using UnityEngine;
using Zenject;

namespace Sources.Variant3.PrefabsCreation
{
    public class UnitCreation : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private CameraControl _cameraControl;
        [SerializeField] private Transform _creationPos;
        private GameObject _createdObject;
        private CameraControl _createdCamera; 
        public GameObject CreatedObject => _createdObject;
        public CameraControl CreatedCamera => _createdCamera;

        [Inject]
        public void Init(RootObjectsCreator rootObjectsCreator)
        {
            Create(rootObjectsCreator.RootObj.transform);
        }
        private void Create(Transform parent)
        {
            _createdObject = Instantiate(_prefab, parent, true);
            _createdCamera =  Instantiate(_cameraControl, parent, true);
            _createdCamera.SetTarget(_createdObject);

            _createdObject.transform.position = _creationPos.position;
            _createdObject.transform.rotation = _creationPos.rotation;
        }
        
    }
}
