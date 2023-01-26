using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class AreaSelector : MonoBehaviour
{
    public event Action<Rect> AreaSelectedEvent;
    public event Action<Rect> AreaUpdatedEvent;

    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Input _input;

    [Inject]
    public void Constructor(Input input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _input.Command.Select.started += StartSelecting;
        _input.Command.Select.performed += UpdateArea;
        _input.Command.Select.canceled += EndSelecting;
    }
    
    private void OnDisable()
    {
        _input.Command.Select.started -= StartSelecting;
        _input.Command.Select.performed -= UpdateArea;
        _input.Command.Select.canceled -= EndSelecting;
    }

    private void StartSelecting(InputAction.CallbackContext callbackContext)
    {
        _startPoint = callbackContext.action.ReadValue<Vector2>();
    }

    private void UpdateArea(InputAction.CallbackContext callbackContext)
    {
        _endPoint = callbackContext.action.ReadValue<Vector2>();
        var rect = GetRectFromPoints(_startPoint, _endPoint);
        AreaUpdatedEvent?.Invoke(rect);
    }

    private void EndSelecting(InputAction.CallbackContext callbackContext)
    {
        var rect = GetRectFromPoints(_startPoint, _endPoint);
        AreaSelectedEvent?.Invoke(rect);
    }

    private static Rect GetRectFromPoints(Vector2 start, Vector2 end)
    {
        var size = end - start;
        return new Rect(start, size);
    }
}
