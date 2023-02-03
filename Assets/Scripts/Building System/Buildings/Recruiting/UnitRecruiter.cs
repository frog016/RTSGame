using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class UnitRecruiter : MonoBehaviour
{
    [SerializeField] private Transform _rallyPoint;

    private bool _inProcess;
    private IFactory _factory;
    private ResourceStorage _storage;
    private Queue<UnitRecruitingData> _recruitingQueue;


    [Inject]
    public void Constructor(IFactory factory, ResourceStorage storage)
    {
        _factory = factory;
        _storage = storage;
    }

    private void Update()
    {
        if (_inProcess || _recruitingQueue.Count == 0)
            return;

        var recruitingData = _recruitingQueue.Dequeue();
        StartCoroutine(ProduceUnitCoroutine(recruitingData));
    }

    public bool TryProduce(UnitRecruitingData recruitingData)
    {
        if (recruitingData.RecruitingCost.Any(data => !_storage.IsEnough(data.Resource, data.Price)))
            return false;

        _recruitingQueue.Enqueue(recruitingData);
        recruitingData.RecruitingCost.Apply(data => _storage.SpendResource(data.Resource, data.Price));
        return true;
    }

    private IEnumerator ProduceUnitCoroutine(UnitRecruitingData recruitingData)
    {
        _inProcess = true;
        yield return new WaitForSeconds(recruitingData.RecruitingTime);
        _factory.CreatePrefab(recruitingData.Prefab, _rallyPoint.position, Quaternion.identity);
        _inProcess = false;
    }
}