using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Blueprint))]
public class DraggableObject : MonoBehaviour, IDraggable
{
    private Blueprint _blueprint;
    private Tilemap _tilemap;
    private Vector3 _offset;

    private bool _isDragging;

    public void Constructor(Tilemap tilemap)
    {
        _tilemap = tilemap;

        _blueprint = GetComponent<Blueprint>();
        _offset = new Vector3(_tilemap.layoutGrid.cellSize.x, _blueprint.Size.y, _tilemap.layoutGrid.cellSize.z) / 2;
    }

    private void Update()
    {
        if (!_isDragging)
            return;

        var position = _tilemap.WorldToCell(transform.position) + _offset;
        transform.position = position;
    }

    private void OnMouseUp()
    {
        EndDrag();
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
}