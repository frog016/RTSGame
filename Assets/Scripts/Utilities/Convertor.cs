using UnityEngine;

public static class Convertor
{
    private static readonly Camera _camera = Camera.main;
    private static readonly float _maxDistance = 1000f;

    public static bool ScreenPointToHit(Vector3 screenPoint, out RaycastHit raycastHit)
    {
        raycastHit = default;
        var ray = _camera.ScreenPointToRay(screenPoint);
        if (!Physics.Raycast(ray, out var hit))
            return false;

        raycastHit = hit;
        return true;
    }

    public static bool ScreenPointToHit(Vector3 screenPoint, LayerMask mask, out RaycastHit raycastHit)
    {
        raycastHit = default;
        var ray = _camera.ScreenPointToRay(screenPoint);
        if (!Physics.Raycast(ray, out var hit, _maxDistance, mask))
            return false;

        raycastHit = hit;
        return true;
    }

    public static bool ScreenToSurface(Vector3 screenPoint, out Vector3 surfacePoint)
    {
        surfacePoint = default;
        var ray = _camera.ScreenPointToRay(screenPoint);
        if (!Physics.Raycast(ray, out var hit)) 
            return false;

        surfacePoint = hit.point;
        return true;
    }

    public static bool ScreenToSurface(Vector3 screenPoint, LayerMask mask, out Vector3 surfacePoint)
    {
        surfacePoint = default;
        var ray = _camera.ScreenPointToRay(screenPoint);
        if (!Physics.Raycast(ray, out var hit, _maxDistance, mask))
            return false;

        surfacePoint = hit.point;
        return true;
    }
}
