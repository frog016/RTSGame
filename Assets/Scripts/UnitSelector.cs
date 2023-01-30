using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class UnitSelector : MonoBehaviour
{
    private ISelector _selector;
    private AreaSelector _areaSelector;
    private List<ISelectable> _selectedUnits;

    [Inject]
    public void Constructor(ISelector selector, AreaSelector areaSelector)
    {
        _selector = selector;
        _areaSelector = areaSelector;
        _selectedUnits = new List<ISelectable>();
    }

    private void OnEnable()
    {
        _areaSelector.AreaSelectedEvent += Select;
    }

    private void OnDisable()
    {
        _areaSelector.AreaSelectedEvent -= Select;
    }

    public T[] GetSelectedUnits<T>()
    {
        return _selectedUnits
            .Cast<Component>()
            .Select(component => component.GetComponent<T>())
            .ToArray();
    }

    private void Select(Rect screenRect)
    {
        Deselect();
        _selectedUnits = _selector.Select(screenRect)
            .ApplyLazy(selectable => selectable.OnSelect())
            .ToList();
    }

    private void Deselect()
    {
        _selectedUnits
            .Apply(selectable => selectable.OnDeselect());
    }
}