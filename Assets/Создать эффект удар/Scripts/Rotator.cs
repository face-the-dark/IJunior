using UnityEngine;

public class Rotator : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";
    private const int InvertScale = -1;

    [SerializeField] private RotationAxis _rotationAxis = RotationAxis.X;
    [SerializeField] private float _rotationSpeed = 80f;
    [SerializeField] private bool _isInverControl = true;

    private void Update()
    {
        float directionX = Input.GetAxis(MouseX);
        float directionY = Input.GetAxis(MouseY);

        switch (_rotationAxis)
        {
            case RotationAxis.X:
                RotateByAxisX(directionX);
                break;

            case RotationAxis.Y:
                RotateByAxisY(directionY);
                break;
        }
    }

    private void RotateByAxisX(float directionX)
    {
        float newRotationY = transform.rotation.eulerAngles.y + directionX * _rotationSpeed * Time.deltaTime;
        transform.rotation =
            Quaternion.Euler(transform.rotation.eulerAngles.x, newRotationY, transform.rotation.eulerAngles.z);
    }
    
    private void RotateByAxisY(float directionY)
    {
        directionY = _isInverControl ? directionY * InvertScale : directionY;
        
        float newRotationX = transform.rotation.eulerAngles.x + directionY * _rotationSpeed * Time.deltaTime;
        transform.rotation =
            Quaternion.Euler(newRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}