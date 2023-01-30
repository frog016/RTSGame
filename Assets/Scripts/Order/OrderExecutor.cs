using System.Collections.Generic;
using UnityEngine;

public class OrderExecutor : MonoBehaviour
{
    private Queue<ICommand> _orderQueue;
    private ICommand _currentCommand;

    private void Awake()
    {
        _orderQueue = new Queue<ICommand>();
    }

    private void Update()
    {
        if (_currentCommand == null && !_orderQueue.TryDequeue(out _currentCommand))
            return;

        _currentCommand.Execute(gameObject);
        if (_currentCommand.IsCompleted)
            _currentCommand = null;
    }

    public void AppendToExecute(ICommand command)
    {
        _orderQueue.Enqueue(command);
    }

    public void ExecuteImmediately(ICommand command)
    {
        _orderQueue.Clear();
        _currentCommand = command;
    }
}
