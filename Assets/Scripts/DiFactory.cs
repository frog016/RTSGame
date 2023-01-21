using UnityEngine;
using Zenject;

public class DiFactory : IFactory
{
    private readonly DiContainer _container;

    public DiFactory(DiContainer container)
    {
        _container = container;
    }

    public T Create<T>()
    {
        return _container.Instantiate<T>();
    }

    public T CreateFromPrefabForComponent<T>(T prefab, Vector3 position, Quaternion rotation) where T : Component
    {
        var createdObject = _container.InstantiatePrefabForComponent<T>(prefab);
        createdObject.transform.SetPositionAndRotation(position, rotation);

        return createdObject;
    }
}