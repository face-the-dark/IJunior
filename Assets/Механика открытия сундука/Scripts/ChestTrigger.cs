using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    private const KeyCode InteractKeyCode = KeyCode.E;
    
    [SerializeField] private Chest _chest;

    private bool _isOpen;
    private bool _hasOpener;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ChestOpener>())
        {
            _hasOpener = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ChestOpener>())
        {
            _hasOpener = false;

            if (_isOpen)
            {
                CloseChest();
            }
        }
    }

    private void Update()
    {
        if (_hasOpener && Input.GetKeyDown(InteractKeyCode))
        {
            if (_isOpen)
            {
                CloseChest();
            }
            else
            {
                OpenChest();
            }
        }
    }

    private void CloseChest()
    {
        _isOpen = false;
        _chest.Close();
    }

    private void OpenChest()
    {
        _isOpen = true;
        _chest.Open();
    }
}