using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HandAnimator))]
[RequireComponent(typeof(CollisionDetector))]
public class Hand :  MonoBehaviour
{
    private HandAnimator _handAnimator;
    private CollisionDetector _collisionDetector;

    private void Awake()
    {
        _handAnimator = GetComponent<HandAnimator>();
        _collisionDetector = GetComponent<CollisionDetector>();        
    }

    private void OnEnable() => 
        _collisionDetector.Detected += OnCollisionDetected;

    private void OnDisable() => 
        _collisionDetector.Detected -= OnCollisionDetected;

    public void Punch() => 
        _handAnimator.PlayPunch();

    private void OnCollisionDetected(List<Collider> detectedColliders)
    {
        foreach (Collider detectedCollider in detectedColliders)
            _handAnimator.PlayCollisionParticles();
    }
}