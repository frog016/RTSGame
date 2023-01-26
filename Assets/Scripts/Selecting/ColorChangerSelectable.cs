using UnityEngine;

public class ColorChangerSelectable : MonoBehaviour, ISelectable
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _selectedMaterial;
    [SerializeField] private MeshRenderer _renderer;

    public void OnSelect()
    {
        _renderer.material = _selectedMaterial;
    }

    public void OnDeselect()
    {
        _renderer.material = _defaultMaterial;
    }
}
