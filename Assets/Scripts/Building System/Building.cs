using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector3 _size;
    [SerializeField] private BoxCollider _boxCollider;

    public Vector3 Size => _size;

    private void OnValidate()
    {
        _boxCollider.size = _size;
    }
}
