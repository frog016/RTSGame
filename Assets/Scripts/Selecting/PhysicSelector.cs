using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhysicSelector : ISelector
{
    private readonly Camera _camera;
    private readonly LayerMask _layer;

    public PhysicSelector(Camera camera, LayerMask layer)
    {
        _camera = camera;
        _layer = layer;
    }

    public IEnumerable<ISelectable> Select(Rect rect)
    {
        var projectedVertices = ProjectVerticesToPlane(rect);
        var bounds = CreateBoundsByVertices(projectedVertices);

        foreach (var collider in Physics.OverlapBox(bounds.center, bounds.size / 2, Quaternion.identity, _layer))
        {
            var a = collider.GetComponent<ISelectable>();
            if (collider.TryGetComponent<ISelectable>(out var selectable))
                yield return selectable;
        }
    }

    private Vector3[] ProjectVerticesToPlane(Rect rect)
    {
        var vertices = new List<Vector3>();
        foreach (var vertex in rect.GetRectVertices())
        {
            var ray = _camera.ScreenPointToRay(vertex);
            if (Physics.Raycast(ray, out var hit, 1000f, _layer))
            {
                vertices.Add(hit.point);
            }
        }

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
