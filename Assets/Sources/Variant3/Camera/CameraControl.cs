using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _target;
    public Camera Camera => _camera;
    
    public void SetTarget(GameObject target)
    {
        _target = target;
    }
    private void MoveForTarget()
    {
        transform.position = _target.transform.position - _offset;
    }
    private void Rotation()
    {
        transform.eulerAngles = _rotation;
    }
    public void LateUpdate()
    {
        MoveForTarget();
        Rotation();
    }
}
