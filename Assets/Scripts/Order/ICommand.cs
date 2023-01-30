using UnityEngine;

public interface ICommand
{
    bool IsCompleted { get; }
    void Execute(GameObject actor);
}