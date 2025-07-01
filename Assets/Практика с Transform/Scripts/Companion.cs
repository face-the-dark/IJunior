using UnityEngine;

public class Companion : Follower
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _lengthRay = 1.0f;
    [SerializeField] private Color _rayColor = Color.red;
    
    private Vector3 _offset;
    
    private void Start()
    {
        _offset = transform.position - Target.position;
    }

    protected override void Move()
    {
        transform.position = Target.position + _offset;
        transform.RotateAround(Target.position, Vector3.up, Speed);
        transform.LookAt(_target.position);
        _offset = transform.position - Target.position;
        
        Debug.DrawRay(transform.position, transform.forward * _lengthRay, _rayColor);
    }
}