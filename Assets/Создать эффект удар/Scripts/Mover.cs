using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _moveSpeed = 10.0f;

    private void Update()
    {
        float directionX = Input.GetAxis(Horizontal);
        float directionZ = Input.GetAxis(Vertical);

        Vector3 direction = (transform.right * directionX + transform.forward * directionZ).normalized;
        Vector3 movement = direction * (_moveSpeed * Time.deltaTime);
        
        transform.position += movement;
    }
}