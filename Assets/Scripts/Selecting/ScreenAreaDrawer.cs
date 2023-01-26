using UnityEngine;

public class ScreenAreaDrawer : IAreaDrawer
{
    private readonly RectTransform _areaRect;

    public ScreenAreaDrawer(RectTransform areaRect)
    {
        _areaRect = areaRect;
    }

    public void DrawArea(Rect screenRect)
    {
        _areaRect.anchoredPosition = screenRect.center;
        _areaRect.sizeDelta = screenRect.size.Abs();
    }

    public void EndDraw()
    {
        _areaRect.sizeDelta = Vector2.zero;
    }
}

