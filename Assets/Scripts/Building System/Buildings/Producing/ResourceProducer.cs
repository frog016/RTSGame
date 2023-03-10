using UnityEngine;
using Zenject;

public class ResourceProducer : AutomaticProducer
{
    [SerializeField] private Resource _resourceType;
    [SerializeField] private int _amount;

    private ResourceStorage _resourceStorage;

    [Inject]
    public void Constructor(ResourceStorage resourceStorage)
    {
        _resourceStorage = resourceStorage;
    }

    protected override void Produce()
    {
        _resourceStorage.AddResource(_resourceType, _amount);
    }
}
