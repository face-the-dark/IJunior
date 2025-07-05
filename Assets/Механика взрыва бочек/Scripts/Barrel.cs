using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 700.0f;
    [SerializeField] private float _explosionRadius = 20.0f;
    [SerializeField] private ParticleSystem _explosionEffect;

    private void OnMouseUpAsButton()
    {
        Explode();
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> rigidbodies = new List<Rigidbody>();
        
        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                rigidbodies.Add(hit.attachedRigidbody);
            }
        }

        return rigidbodies;
    }
}