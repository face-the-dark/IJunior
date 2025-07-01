using UnityEngine;

public abstract class Follower : MonoBehaviour
{
    [SerializeField] protected Transform Target;
    [SerializeField] protected float Speed = 1.0f;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();
}