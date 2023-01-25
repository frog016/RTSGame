using System.Collections;
using UnityEngine;

public abstract class AutomaticProducer : MonoBehaviour
{
    [SerializeField] private float _producingTime;
    [SerializeField] protected int _amount;

    protected abstract void Produce();

    private IEnumerator ProduceCoroutine()
    {
        yield return new WaitForSeconds(_producingTime);
        Produce();
    }
}
