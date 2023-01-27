using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class UnitSelector : MonoBehaviour
{
    private ISelector _selector;
    private AreaSelector _areaSelector;
    private List<ISelectable> _selectedUnits;

    private ICommand _command;
    private Input _input;

    [Inject]
    public void Constructor(ISelector selector, Input input, AreaSelector areaSelector)
    {
        _selector = selector;
        _areaSelector = areaSelector;
        _selectedUnits = new List<ISelectable>();
        _command = new MovementCommand(new SquareFormation());
        _input = input;
    }

    private void OnEnable()
    {
        _areaSelector.AreaSelectedEvent += Select;
        _input.Command.ActionPoint.started += SendCommand;
    }

    private void OnDisable()
    {
        _areaSelector.AreaSelectedEvent -= Select;
        _input.Command.ActionPoint.started -= SendCommand;
    }

    public T[] GetSelectedUnits<T>()
    {
        return _selectedUnits
            .Cast<Component>()
            .Select(component => component.GetComponent<T>())
            .ToArray();
    }

    private void SendCommand(InputAction.CallbackContext callbackContext)
    {
        var screenPosition = callbackContext.action.ReadValue<Vector2>();
        var ray = Camera.main.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out var hit, 1000f))
        {
            Debug.Log(hit.point);
            _command.Execute(hit.point, this);
        }
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