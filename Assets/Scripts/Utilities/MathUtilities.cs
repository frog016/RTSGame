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

    public static Vector3 ToXZPlane(this Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }
}