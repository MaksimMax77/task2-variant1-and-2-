using UnityEngine;

namespace Sources.Variant1
{
    public class ObjectRotation : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotation; 
        
        private void Update()
        {
            transform.Rotate(_rotation);
        }
    }
}
