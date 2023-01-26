using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class LinqExtensions
{
    public static IEnumerable<T> Apply<T>(this IEnumerable<T> collection, Action<T> action)
    {
        var array = collection.ToArray();
        foreach (var element in array)
            action?.Invoke(element);

        return array;
    }

    public static IEnumerable<T> ApplyLazy<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var element in collection)
        {
            action?.Invoke(element);
            yield return element;
        }
    }

    public static Vector3 Sum(this IEnumerable<Vector3> collection)
    {
        return collection.Aggregate(Vector3.zero, (current, vector) => current + vector);
    }
}
