using System;
using UnityEngine;

public class BuildingArea : MonoBehaviour
{
    public void Build(Building building, Vector3 position, Quaternion rotation)
    {
        if (!IsEmpty(position))
            throw new InvalidOperationException("The position you have chosen is occupied. Please check it before placing.");

        var createdBuilding = Instantiate(building, position, rotation);
    }

    public bool IsEmpty(Vector3 position)
    {
        return !Physics.CheckBox(position, Vector3.one / 2, Quaternion.identity, gameObject.layer);
    }
}
