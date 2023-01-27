using UnityEngine;

public interface IFormation
{
    Vector3[] GetFormationPositions(Vector3 center, int count, float indent);
}
