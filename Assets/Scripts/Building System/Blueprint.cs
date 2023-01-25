using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SnappableObject))]
public class Blueprint : MonoBehaviour
{
    [SerializeField] private Building _buildingPrefab;

    public Action ObjectPlacedEvent;

    private BuildingArea _buildingArea;
    private SnappableObject _snappable;

    [Inject]
    public void Constructor(BuildingArea buildingArea)
    {
        _buildingArea = buildingArea;
    }

    private void Awake()
    {
        _snappable = GetComponent<SnappableObject>();
        _snappable.Offset = new Vector3(0, _buildingPrefab.Size.y, 0) / 2;
    }

    private void OnEnable()
    {
        _snappable.ObjectPlacedEvent += TryPlaceBlueprint;
    }

    private void OnDisable()
    {
        _snappable.ObjectPlacedEvent -= TryPlaceBlueprint;
    }

    public void TryPlaceBlueprint()
    {
        if (!_buildingArea.IsValidPosition(transform.position, _buildingPrefab.Size, transform.rotation))
            return;

        _buildingArea.Build(_buildingPrefab, transform.position, transform.rotation);
        ObjectPlacedEvent?.Invoke();
        Destroy(gameObject);
    }
}
