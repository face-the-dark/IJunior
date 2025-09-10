using UnityEngine;

public class Block : MonoBehaviour
{
    public void Explode() => 
        Destroy(gameObject);
}