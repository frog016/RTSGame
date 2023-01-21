using System;
using UnityEngine;
using Zenject;

public class BuildingArea : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private IFactory _factory;

    [Inject]
    public void Constructor(IFactory factory)
    {
        _factory = factory;
    }

    public void Build(Building building, Vector3 position, Quaternion rotation)
    {
        if (!IsEmpty(position))
            throw new InvalidOperationException("The position you have chosen is occupied. Please check it before placing.");

        var createdBuilding = _factory.CreateFromPrefabForComponent(building, position, rotation);
    }

    public bool IsEmpty(Vector3 position)
    {
        return !Physics.CheckBox(position, Vector3.one / 2, Quaternion.identity, _layer);
    }
}
