using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grenade : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _explosionDelay = 2f;
    [SerializeField] private ParticleSystem _explosionEffect;

    private Rigidbody _rigidbody;

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody>();

    private void Update()
    {
        if (_explosionDelay <= 0f) 
            Explode();
        
        _explosionDelay -= Time.deltaTime;
    }

    public void Throw(Vector3 force) => 
        _rigidbody.AddForce(force);

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in hits)
            if (hit.TryGetComponent(out Block block))
                block.Explode();

        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}