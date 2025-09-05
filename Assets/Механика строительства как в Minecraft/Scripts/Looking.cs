using UnityEngine;

public class Looking : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    
    [SerializeField] private float _rotationSpeed = 150f;
    [SerializeField] private Transform _camera;
    
    private void Update()
    {
        transform.Rotate(Input.GetAxis(MouseX) * _rotationSpeed * Time.deltaTime * Vector3.up);
        _camera.transform.Rotate(-Input.GetAxis(MouseY) * _rotationSpeed * Time.deltaTime * Vector3.right);
    }
}