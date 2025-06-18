using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float _rotationSelfSpeed;
    [SerializeField] private float _rotationAroundSpeed;
    [SerializeField] private Transform _rotationCenter;

    private Vector3 _offset;
    private bool _isNotNullRotationCenter;

    private void Start()
    {
        _isNotNullRotationCenter = _rotationCenter != null;

        if (_isNotNullRotationCenter)
            _offset = transform.position - _rotationCenter.position;
    }

    private void Update()
    {
        transform.Rotate(transform.up, _rotationSelfSpeed * Time.deltaTime, Space.Self);

        if (_isNotNullRotationCenter)
        {
            transform.position = _rotationCenter.position + _offset;
            transform.RotateAround(_rotationCenter.position, Vector3.up, _rotationAroundSpeed * Time.deltaTime);
            _offset = transform.position - _rotationCenter.position;
        }
    }
}