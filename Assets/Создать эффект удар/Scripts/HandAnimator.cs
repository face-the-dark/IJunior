using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CollisionDetector))]
public class HandAnimator : MonoBehaviour
{
    private static readonly int PunchKey = Animator.StringToHash("Punch");

    [SerializeField] private ParticleSystem _collisionParticles;

    private Animator _handAnimator;

    private void Awake() =>
        _handAnimator = GetComponent<Animator>();

    public void PlayPunch() =>
        _handAnimator.SetTrigger(PunchKey);

    public void PlayCollisionParticles()
    {
        ParticleSystem particles = Instantiate(_collisionParticles, transform.position, transform.rotation);
        StartCoroutine(DestroyParticles(particles));
    }

    private IEnumerator DestroyParticles(ParticleSystem particles)
    {
        while (particles.IsAlive())
            yield return null;
        
        Destroy(particles.gameObject);
    }
}