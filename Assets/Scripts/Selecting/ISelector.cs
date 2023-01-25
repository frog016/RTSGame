using System.Collections.Generic;
using UnityEngine;

public interface ISelector
{
    IEnumerable<ISelectable> Select(Rect rect);
}
