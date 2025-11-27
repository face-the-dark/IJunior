using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private const int ResultSize = 100;

    [SerializeField] private float _detectionRadius = 0.5f;
    [SerializeField] private LayerMask _detectionLayer;

    private Collider[] _results = new Collider[ResultSize];

    public event Action<List<Collider>> Detected;

    public void Detect()
    {
        ClearResults();

        Physics.OverlapSphereNonAlloc(transform.position, _detectionRadius, _results, _detectionLayer);

        Detected?.Invoke(CalculateNonNullElements());
    }

    private void ClearResults()
    {
        for (int i = 0; i < _results.Length; i++) 
            _results[i] = null;
    }

    private List<Collider> CalculateNonNullElements()
    {
        List<Collider> colliders = new List<Collider>();

        foreach (Collider result in _results)
            if (result != null)
                colliders.Add(result);

        return colliders;
    }
}