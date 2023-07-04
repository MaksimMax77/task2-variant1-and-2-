using UnityEngine;
using Zenject;

namespace Sources.Variant3.PrefabsCreation
{
    public class UnitCreation : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private CameraControl _cameraControl;
        [SerializeField] private Transform _creationPos;
        [SerializeField] private Transform _parent;
        private GameObject _createdObject;
        private CameraControl _createdCamera; 
        public GameObject CreatedObject => _createdObject;
        public CameraControl CreatedCamera => _createdCamera;

        [Inject]
        public void Init()
        {
            Create();
        }
        private void Create()
        {
            _createdObject = Instantiate(_prefab, _parent, true);
            _createdCamera =  Instantiate(_cameraControl, _parent, true);
            _createdCamera.SetTarget(_createdObject);

            _createdObject.transform.position = _creationPos.position;
            _createdObject.transform.rotation = _creationPos.rotation;
        }
        
    }
}
