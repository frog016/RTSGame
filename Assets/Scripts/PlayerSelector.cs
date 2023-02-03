using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayerSelector : MonoBehaviour
{
    public event Action<ISelectable[]> SelectedEvent; 
    public event Action DeselectedEvent; 

    private ISelector _selector;
    private AreaSelector _areaSelector;
    private List<ISelectable> _selectedObject;

    [Inject]
    public void Constructor(ISelector selector, AreaSelector areaSelector)
    {
        _selector = selector;
        _areaSelector = areaSelector;
        _selectedObject = new List<ISelectable>();
    }

    private void OnEnable()
    {
        _areaSelector.AreaSelectedEvent += Select;
    }

    private void OnDisable()
    {
        _areaSelector.AreaSelectedEvent -= Select;
    }

    public T[] GetSelectedObject<T>()
    {
        return _selectedObject.SelectableAs<T>();
    }

    private void Select(Rect screenRect)
    {
        Deselect();
        _selectedObject = _selector.Select(screenRect)
            .ApplyLazy(selectable => selectable.OnSelect())
            .ToList();

        SelectedEvent?.Invoke(_selectedObject.ToArray());
    }

    private void Deselect()
    {
        _selectedObject
            .Apply(selectable => selectable.OnDeselect());

        DeselectedEvent?.Invoke();
    }
}