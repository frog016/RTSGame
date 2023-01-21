using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

public class BuildingArea : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private IFactory _factory;
    private Tilemap _tilemap;

    [Inject]
    public void Constructor(IFactory factory, Tilemap tilemap)
    {
        _factory = factory;
        _tilemap = tilemap;
    }

    public void Build(Building building, Vector3 position, Quaternion rotation)
    {
        if (!IsEmpty(position))
            throw new InvalidOperationException("The position you have chosen is occupied. Please check it before placing.");

        var clampedPosition = GetCellCenterPosition(position);
        var createdBuilding = _factory.CreateFromPrefabForComponent(building, clampedPosition, rotation);
    }

    public bool IsEmpty(Vector3 position)
    {
        return !Physics.CheckBox(position, Vector3.one / 2, Quaternion.identity, _layer);
    }

    private Vector3 GetCellCenterPosition(Vector3 position)
    {
        var clampedPosition = _tilemap.GetCellCenterWorld(_tilemap.WorldToCell(position));
        clampedPosition.y = position.y;
        return clampedPosition;
    }
}
