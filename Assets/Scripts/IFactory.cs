using UnityEngine;

public interface IFactory
{
    T Create<T>();
    T CreatePrefab<T>(T prefab, Vector3 position, Quaternion rotation) where T : Object;
    T CreateFromPrefabForComponent<T>(T prefab, Vector3 position, Quaternion rotation) where T : Component;
}