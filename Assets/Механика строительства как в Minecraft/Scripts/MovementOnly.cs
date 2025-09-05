using UnityEngine;

public class MovementOnly : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical)).normalized;
        
        transform.Translate(direction * (_speed * Time.deltaTime));
    }
}
