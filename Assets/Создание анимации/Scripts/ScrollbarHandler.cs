using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class ScrollbarHandler : MonoBehaviour
{
    private static readonly int SpeedKey = Animator.StringToHash("Speed");
    
    [SerializeField] private Animator _animator;
    
    private Scrollbar _scrollbar;

    private void Awake()
    {
        _scrollbar = GetComponent<Scrollbar>();
    }

    private void OnEnable()
    {
        _scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
    }

    private void OnDisable()
    {
        _scrollbar.onValueChanged.RemoveListener(OnScrollbarValueChanged);
    }

    private void OnScrollbarValueChanged(float value)
    {
        _animator.SetFloat(SpeedKey, value);
    }
}
