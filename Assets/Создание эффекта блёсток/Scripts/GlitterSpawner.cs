using UnityEngine;

public class GlitterSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _glitterFX;

    public void Spawn(Vector3 position, Quaternion rotation) => 
        Instantiate(_glitterFX, position, rotation);
}
