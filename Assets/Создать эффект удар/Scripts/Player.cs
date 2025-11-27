using UnityEngine;

public class Player : MonoBehaviour
{
    private const int PunchMouseButton = 0;
    
    [SerializeField] private Hand _hand;

    private void Update()
    {
        if (Input.GetMouseButtonDown(PunchMouseButton)) 
            _hand.Punch();
    }
}