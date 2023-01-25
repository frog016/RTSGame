using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

public class BuildingArea : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    [SerializeField] private Vector2 _size;

    private IFactory _factory;
    private Tilemap _tilemap;
    private Bounds _border;

    [Inject]
    public void Constructor(IFactory factory, Tilemap tilemap)
    {
        _factory = factory;
        _tilemap = tilemap;
    }

    private void Awake()
    {
        _border = new Bounds(transform.position, new Vector3(_size.x, 0, _size.y));
    }

    public void Build(Building building, Vector3 position, Quaternion rotation) // Добавить умножение rotation * building.Size, когда будет добавлен поворот здания
    {
        if (!IsValidPosition(position, building.Size, rotation))
            throw new InvalidOperationException("The position you have chosen is occupied or out of bounds. Please check it before placing.");

        var clampedPosition = GetCellCenterPosition(position, building.Size);
        var createdBuilding = _factory.CreateFromPrefabForComponent(building, clampedPosition, rotation);
    }

    public bool IsValidPosition(Vector3 position, Vector3 size, Quaternion rotation)
    {
        position = position.ToXZPlane();
        size = size.ToXZPlane();
        return IsEmpty(position, size, rotation) && CheckInsideBorder(position, size);
    }

    private bool IsEmpty(Vector3 position, Vector3 size, Quaternion rotation)
    {
        return !Physics.CheckBox(position, size / 2, rotation, _layer);
    }

    private bool CheckInsideBorder(Vector3 position, Vector3 size)
    {
        return _border.ContainsBounds(position, size);
    }

    private Vector3 GetCellCenterPosition(Vector3 position, Vector3 size)
    {
        var clampedPosition = _tilemap.GetCellCenterWorld(_tilemap.WorldToCell(position));
        clampedPosition.y = position.y;
        return clampedPosition + new Vector3((int)size.x % 2 == 0 ? 1 : 0, 0, (int)size.z % 2 == 0 ? 1 : 0) / 2;
    }
}
