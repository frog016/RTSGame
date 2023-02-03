using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Recruiting", fileName = "UnitRecruitingData")]
public class UnitRecruitingData : ScriptableObject
{
    [SerializeField] private Cost[] _cost;
    [SerializeField] private float _recruitingTime;
    [SerializeField] private GameObject _prefab;

    public Cost[] RecruitingCost => _cost;
    public float RecruitingTime => _recruitingTime;
    public GameObject Prefab => _prefab;

    [Serializable]
    public struct Cost
    {
        [SerializeField] private Resource _resource;
        [SerializeField] private int _price;

        public Resource Resource => _resource;
        public int Price => _price;
    }
}