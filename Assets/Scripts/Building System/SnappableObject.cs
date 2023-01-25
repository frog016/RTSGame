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
    private Camera _camera;

    [Inject]
    public void Constructor(Input input)
    {
        _input = input;
        _camera = Camera.main;
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
        var ray = _camera.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out var hit, 100, _surfaceLayer))
        {
            transform.position = hit.point + Offset;
        }
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