using UnityEngine;

public class Leader : MonoBehaviour
{
    private static readonly int SpeedKey = Animator.StringToHash("Speed");
    
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointIndex;

    private void Start()
    {
        _currentWaypointIndex = 0;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(_waypoints[_currentWaypointIndex].position - transform.position);
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, _speed * Time.deltaTime);
        
        if (transform.position == _waypoints[_currentWaypointIndex].position)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;;
        }
        
        _animator.SetFloat(SpeedKey, _speed);
    }
}
