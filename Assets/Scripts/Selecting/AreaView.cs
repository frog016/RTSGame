using UnityEngine;

[RequireComponent(typeof(AreaSelector))]
public class AreaView : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    private IAreaDrawer _areaDrawer;
    private AreaSelector _areaSelector;

    private void Awake()
    {
        _areaDrawer = new ScreenAreaDrawer(_rectTransform);

        _areaSelector = GetComponent<AreaSelector>();
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