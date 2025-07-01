using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private float _gizmosSphereRadius = 0.5f;
    [SerializeField] private Color _gizmosColor = Color.red;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawSphere(transform.position, _gizmosSphereRadius);
    }
}
