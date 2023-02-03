using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SelectableExtensions
{
    public static T SelectableAs<T>(this ISelectable selectable)
    {
        if (selectable is Component component)
            return component.GetComponent<T>();

        throw new InvalidOperationException($"The {selectable} object is not a component of type {typeof(T)}.");
    }

    public static T[] SelectableAs<T>(this IEnumerable<ISelectable> selectable)
    {
        return selectable
            .Select(s => s.SelectableAs<T>())
            .ToArray();
    }
}