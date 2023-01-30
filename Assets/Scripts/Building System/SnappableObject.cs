using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class SnappableObject : MonoBehaviour
{
    [SerializeField] private LayerMask _surfaceLayer;

    public Vector3 Offset { get; set; }
    public Action ObjectPlacedEvent;

    private Input _input;

    [Inject]
    public void Constructor(Input input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _input.Building.Follow.performed += SnapToSurface;
        _input.Building.Place.performed += PlaceToSurface;
        _input.Building.Detach.performed += UndoSnapping;
    }

    private void OnDisable()
    {
        _input.Building.Follow.performed -= SnapToSurface;
        _input.Building.Place.performed -= PlaceToSurface;
        _input.Building.Detach.performed -= UndoSnapping;
    }

    private void SnapToSurface(InputAction.CallbackContext callbackContext)
    {
        var screenPosition = callbackContext.action.ReadValue<Vector2>();
        if (Convertor.ScreenToSurface(screenPosition, _surfaceLayer, out var point))
            transform.position = point + Offset;
    }

    private void PlaceToSurface(InputAction.CallbackContext callbackContext)
    {
        ObjectPlacedEvent?.Invoke();
    }

    private void UndoSnapping(InputAction.CallbackContext callbackContext)
    {
        Destroy(gameObject);
    }
}