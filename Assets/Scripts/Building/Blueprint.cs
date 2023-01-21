using System;
using UnityEngine;
using Zenject;

public class Blueprint : MonoBehaviour
{
    [SerializeField] private Building _buildingPrefab;

    public Action ObjectPlacedEvent;
    public Vector3 Size => _buildingPrefab.Size;

    private BuildingArea _buildingArea;

    [Inject]
    public void Constructor(BuildingArea buildingArea)
    {
        _buildingArea = buildingArea;
    }

    public bool TryPlaceBlueprint()
    {
        if (!_buildingArea.IsEmpty(transform.position))
            return false;

        _buildingArea.Build(_buildingPrefab, transform.position, transform.rotation);
        ObjectPlacedEvent?.Invoke();

        return true;
    }
}
