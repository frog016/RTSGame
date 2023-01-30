using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhysicSelector : ISelector
{
    private readonly LayerMask _layer;

    public PhysicSelector(LayerMask layer)
    {
        _layer = layer;
    }

    public IEnumerable<ISelectable> Select(Rect rect)
    {
        var projectedVertices = ProjectVerticesToPlane(rect);
        var bounds = CreateBoundsByVertices(projectedVertices);

        foreach (var collider in Physics.OverlapBox(bounds.center, bounds.size / 2, Quaternion.identity, _layer))
            if (collider.TryGetComponent<ISelectable>(out var selectable))
                yield return selectable;
    }

    private Vector3[] ProjectVerticesToPlane(Rect rect)
    {
        var vertices = new List<Vector3>();
        foreach (var vertex in rect.GetRectVertices())
            if (Convertor.ScreenToSurface(vertex, _layer, out var point))
                vertices.Add(point);

        return vertices.ToArray();
    }

    private static Bounds CreateBoundsByVertices(Vector3[] vertices)
    {
        var center = vertices.Sum() / vertices.Length;
        var size = (vertices.First() - center).Abs() * 2;
        size.y = 1f;
        return new Bounds(center, size);
    }
}
