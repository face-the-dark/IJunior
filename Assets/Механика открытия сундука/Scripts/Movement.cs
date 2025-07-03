using UnityEngine;

public class Movement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    
    [SerializeField] private float _rotateSpeed = 40.0f;
    [SerializeField] private float _moveSpeed = 10.0f;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);
        
        transform.Rotate(Vector3.up * (rotation * _rotateSpeed * Time.deltaTime));
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        
        transform.Translate(Vector3.forward * (direction * _moveSpeed * Time.deltaTime));
    }
}
