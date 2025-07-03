using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Chest : MonoBehaviour
{
    private static readonly int OpenKey = Animator.StringToHash("Open");
    private static readonly int CloseKey = Animator.StringToHash("Close");
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetTrigger(OpenKey);
    }

    public void Close()
    {
        _animator.SetTrigger(CloseKey);
    }
}
