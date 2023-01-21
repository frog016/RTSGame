using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

[RequireComponent(typeof(Blueprint))]
public class DraggableObject : MonoBehaviour
{
    private Blueprint _blueprint;
    private Tilemap _tilemap;
    private Input _input;
    private Camera _camera;
    private Vector3 _offset;

    private bool _isDragging;

    [Inject]
    public void Constructor(Tilemap tilemap, Input input)
    {
        _tilemap = tilemap;
        _input = input;
        _camera = Camera.main;

        _blueprint = GetComponent<Blueprint>();
        _offset = new Vector3(_tilemap.layoutGrid.cellSize.x, _blueprint.Size.y, _tilemap.layoutGrid.cellSize.z) / 2;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void Update()
    {
        if (!_isDragging)
            return;

        SnapToSurface();
    }

    public void BeginDrag()
    {
        _isDragging = true;
    }

    public void EndDrag()
    {
        if (!_blueprint.TryPlaceBlueprint())
            return;

        _isDragging = false;
        Destroy(gameObject);
    }

    private void SnapToSurface()
    {
        var screenPosition = _input.Building.Follow.ReadValue<Vector2>();
        var ray = _camera.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out var hit))
        {
            transform.position = hit.point + new Vector3(0, _offset.y, 0);
        }
    }
}