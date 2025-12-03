using UnityEngine;

public class GlitterHand : MonoBehaviour
{
    private const int GlitterSpawnButton = 0;
    
    [SerializeField] private GlitterSpawner _glitterSpawner;

    private void Update()
    {
        if (Input.GetMouseButtonDown(GlitterSpawnButton)) 
            _glitterSpawner.Spawn(transform.position, transform.rotation);
    }
}