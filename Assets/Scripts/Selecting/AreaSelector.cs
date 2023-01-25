using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class AreaSelector : MonoBehaviour
{
    public event Action<Rect> AreaSelectedEvent;
    public event Action<Rect> AreaUpdatedEvent;

    private Vector2 _startPoint;
    private Input _input;

    [Inject]
    public void Constructor(Input input)
    {
        _input = input;
    }

    private void StartSelecting(InputAction.CallbackContext callbackContext)
    {
        _startPoint = callbackContext.action.ReadValue<Vector2>();
    }

    private void UpdateArea(InputAction.CallbackContext callbackContext)
    {
        var endPoint = callbackContext.action.ReadValue<Vector2>();
        var rect = GetRectFromPoints(_startPoint, endPoint);
        AreaUpdatedEvent?.Invoke(rect);
    }

    private void EndSelecting(InputAction.CallbackContext callbackContext)
    {
        var endPoint = callbackContext.action.ReadValue<Vector2>();
        var rect = GetRectFromPoints(_startPoint, endPoint);
        AreaSelectedEvent?.Invoke(rect);
    }

    private static Rect GetRectFromPoints(Vector2 start, Vector2 end)
    {
        return new Rect(start, end - start);
    }
}
