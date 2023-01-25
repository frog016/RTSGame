﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Resources/Storage", fileName = "ResourceStorage")]
public class ResourceStorage : ScriptableObject
{
    public Action<Resource, int> ResourceChangedEvent;

    private Dictionary<Resource, int> _storage;

    private void OnEnable()
    {
        _storage = CreateEmptyStorage();
    }

    public void AddResource(Resource resource, int amount)
    {
        _storage[resource] += amount;
        ResourceChangedEvent?.Invoke(resource, amount);
    }

    public void SpendResource(Resource resource, int amount)
    {
        _storage[resource] -= amount;
        ResourceChangedEvent?.Invoke(resource, amount);
    }

    private static Dictionary<Resource, int> CreateEmptyStorage()
    {
        var resourceTypes = Enum.GetValues(typeof(Resource));
        return resourceTypes
            .Cast<Resource>()
            .ToDictionary(resourceType => resourceType, _ => 0);
    }
}
