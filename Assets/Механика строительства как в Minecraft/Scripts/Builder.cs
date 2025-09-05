using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private Transform _raycastStartPoint;
    [SerializeField] private float _raycastDistance = 2f;
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private BuildPreview _buildPreview;

    private RaycastHit _hitInfo;

    private Vector3 BuildPosition => _hitInfo.transform.position + _hitInfo.normal;

    private void Start() =>
        Cursor.lockState = CursorLockMode.Locked;

    private void Update()
    {
        if (_hitInfo.transform == null)
            return;

        if (IsItBlock() == false)
            return;

        if (Input.GetMouseButtonDown(0))
            Build();
    }

    private void FixedUpdate()
    {
        if (CastRay() && IsItBlock())
        {
            if (_buildPreview.IsActive == false)
                _buildPreview.Enable();

            _buildPreview.SetPosition(BuildPosition);
        }
        else
        {
            _buildPreview.Disable();
        }
    }

    private bool IsItBlock() => 
        _hitInfo.transform.GetComponent<Block>() != null;

    private bool CastRay() => 
        Physics.Raycast(_raycastStartPoint.position, _raycastStartPoint.forward, out _hitInfo, _raycastDistance);

    private void Build() =>
        Instantiate(_blockPrefab, BuildPosition, Quaternion.identity);
}