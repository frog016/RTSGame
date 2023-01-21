using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;

    public Vector3 Size => _boxCollider.size;
}
