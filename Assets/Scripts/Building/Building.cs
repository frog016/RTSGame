using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;

    public Vector3 Size { get; private set; }

    private void Awake()
    {
        Size = _boxCollider.size;
    }
}
