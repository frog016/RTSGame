using UnityEngine;
using Zenject;

public class SelectableView : MonoBehaviour
{
    [SerializeField] private SelectableItemView _itemViewPrefab;
    [SerializeField] private RectTransform _group;

    private PlayerSelector _selector;

    [Inject]
    public void Constructor(PlayerSelector selector)
    {
        _selector = selector;
        _selector.SelectedEvent += OnSelected;
        _selector.DeselectedEvent += OnDeselected;
    }

    private void OnDisable()
    {
        _selector.SelectedEvent -= OnSelected;
        _selector.DeselectedEvent -= OnDeselected;
    }

    private void OnSelected(ISelectable[] selectables)
    {
        foreach (var selectable in selectables)
        {
            var itemView = Instantiate(_itemViewPrefab, _group);
            itemView.Initialize(null, selectable.SelectableAs<Damageable>());
        }
    }

    private void OnDeselected()
    {
        _group.DestroyChildren();
    }
}
