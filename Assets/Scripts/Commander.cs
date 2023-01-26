using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Commander : MonoBehaviour
{
    public List<ISelectable> SelectedUnits { get; private set; } = new List<ISelectable>();

    private ISelector _selector;
    private AreaSelector _areaSelector;

    [Inject]
    public void Constructor(ISelector selector, AreaSelector areaSelector)
    {
        _selector = selector;
        _areaSelector = areaSelector;
    }

    private void OnEnable()
    {
        _areaSelector.AreaSelectedEvent += Select;
    }

    private void OnDisable()
    {
        _areaSelector.AreaSelectedEvent -= Select;
    }

    private void Select(Rect screenRect)
    {
        Deselect();
        SelectedUnits = _selector.Select(screenRect)
            .ApplyLazy(selectable => selectable.OnSelect())
            .ToList();
    }

    private void Deselect()
    {
        SelectedUnits
            .Apply(selectable => selectable.OnDeselect());
    }
}