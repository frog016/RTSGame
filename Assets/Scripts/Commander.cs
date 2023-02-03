using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(PlayerSelector))]
public class Commander : MonoBehaviour
{
    private Input _input;
    private PlayerSelector _selector;

    [Inject]
    public void Constructor(Input input)
    {
        _input = input;
        _input.Command.ActionPoint.started += SendCommand;
        _input.Command.AdditionalActionPoint.started += SendAdditionalCommand;
    }

    private void Awake()
    {
        _selector = GetComponent<PlayerSelector>();
    }

    private void SendCommand(InputAction.CallbackContext callbackContext)
    {
        var screenPoint = callbackContext.action.ReadValue<Vector2>();
        ChooseCommandToGive(screenPoint, (executor, command) => executor.ExecuteImmediately(command));
        Debug.Log("Invoke");
    }

    private void SendAdditionalCommand(InputAction.CallbackContext callbackContext)
    {
        var screenPoint = callbackContext.action.ReadValue<Vector2>();
        ChooseCommandToGive(screenPoint, (executor, command) => executor.AppendToExecute(command));
        Debug.Log("Additional Invoke");
    }

    private void ChooseCommandToGive(Vector3 screenPoint, Action<OrderExecutor, ICommand> executeMode)
    {
        if (!Convertor.ScreenPointToHit(screenPoint, out var hit))
            return;

        var damageable = hit.collider.GetComponent<Damageable>();
        ICommand command = damageable != null ? new AttackCommand(damageable) : new MovementCommand(hit.point);
        _selector.GetSelectedObject<OrderExecutor>().Apply(executor => executeMode(executor, command));
    }

    private void OnDestroy()
    {
        _input.Command.ActionPoint.started -= SendCommand;
        _input.Command.AdditionalActionPoint.started -= SendAdditionalCommand;
    }
}