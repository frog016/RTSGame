using UnityEngine;
using Zenject;

public class AreaView : MonoBehaviour
{
    private IAreaDrawer _areaDrawer;
    private AreaSelector _areaSelector;

    [Inject]
    public void Constructor(IAreaDrawer areaDrawer, AreaSelector areaSelector)
    {
        _areaDrawer = areaDrawer;
        _areaSelector = areaSelector;

        _areaSelector.AreaUpdatedEvent += OnAreaUpdated;
        _areaSelector.AreaSelectedEvent += OnAreaSelected;
    }

    private void OnDestroy()
    {
        _areaSelector.AreaUpdatedEvent -= OnAreaUpdated;
        _areaSelector.AreaSelectedEvent -= OnAreaSelected;
    }

    private void OnAreaUpdated(Rect rect)
    {
        _areaDrawer.DrawArea(rect);
    }
    
    private void OnAreaSelected(Rect rect)
    {
        _areaDrawer.EndDraw();
    }
}