using UnityEngine;

public interface ICommand
{
    void Execute(Vector3 target, UnitSelector unitSelector);
}
