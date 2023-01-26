using UnityEngine;

public static class MathUtilities
{
    public static bool ContainsBounds(this Bounds bounds, Vector3 center, Vector3 size)
    {
        var otherBounds = new Bounds(center, size);
        return ContainsBounds(bounds, otherBounds);
    }

    public static bool ContainsBounds(this Bounds bounds, Bounds otherBounds)
    {
        return bounds.Contains(otherBounds.min) && bounds.Contains(otherBounds.max);
    }

    public static Vector2[] GetRectVertices(this Rect rect)
    {
        return new Vector2[]
        {
            rect.min, new Vector2(rect.xMax, rect.yMin),
            rect.max, new Vector2(rect.xMin, rect.yMax)
        };
    }
}