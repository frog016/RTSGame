using System.Linq;
using UnityEngine;

public class SquareFormation : IFormation
{
    public Vector3[] GetFormationPositions(Vector3 center, int count, float indent)
    {
        var sideSize = Mathf.RoundToInt(Mathf.Sqrt(count));
        var localPositions = GetPositionsLocal(sideSize, count, indent);
        
        return localPositions
            .Select(position => position + center)
            .ToArray();
    }

    private static Vector3[] GetPositionsLocal(int size, int count, float indent)
    {
        var result = new Vector3[count];

        var deltaDirection = new Vector3(1, 0, -1);
        var localCenterDelta = deltaDirection * size * indent * Mathf.Sqrt(2) / 2;

        var index = new Vector2Int(0, 0);
        for (var gotten = 0; gotten < count; gotten++)
        {
            var position = new Vector3(index.x * indent, 0, index.y * indent);
            result[gotten] = position - localCenterDelta;

            if (++index.x < size) 
                continue;

            index.x = 0;
            index.y++;
        }

        return result;
    }
}

