using UnityEngine;

public class LinearFollower : Follower
{
    private static readonly int SpeedKey = Animator.StringToHash("Speed");
    
    [SerializeField] private Animator _animator;
    
    protected override void Move()
    {
        transform.rotation = Quaternion.LookRotation(Target.position - transform.position);
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        
        _animator.SetFloat(SpeedKey, Speed);
    }
}