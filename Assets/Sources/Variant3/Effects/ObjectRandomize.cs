using UnityEngine;

namespace Sources.Variant3.Effects
{
    public class ObjectRandomize : MonoBehaviour
    {
        private Vector3 _defaultScale;

        [SerializeField] private bool _randomScale;
        [SerializeField] private bool _randomRotation;

        [SerializeField] private float _minScale; 
        [SerializeField] private float _maxScale;
        [SerializeField] private float _minRotation; 
        [SerializeField] private float _maxRotaion;

        private void Awake()
        {
            _defaultScale = transform.localScale;
        }
        
        private void OnEnable()
        {
            if (_randomScale)
            {
                transform.localScale = _defaultScale*Random.Range(_minScale, _maxScale);
            }

            if (_randomRotation)
            {
                 transform.rotation *= Quaternion.Euler(0, 0, Random.Range(_minRotation, _maxRotaion));
            }
        }
    }
}