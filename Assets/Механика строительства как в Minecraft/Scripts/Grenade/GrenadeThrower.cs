using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private Grenade _grenadePrefab;
    [SerializeField] private Transform _throwPoint;
    [SerializeField] private float _throwForce = 150f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Grenade grenade = Instantiate(_grenadePrefab, _throwPoint.position, _throwPoint.rotation);
            grenade.Throw(_throwPoint.forward * _throwForce);
        }
    }
}