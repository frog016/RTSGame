using System.Collections;
using UnityEngine;

public abstract class AutomaticProducer : MonoBehaviour
{
    [SerializeField] private float _producingTime;

    protected abstract void Produce();

    private IEnumerator ProduceCoroutine()
    {
        yield return new WaitForSeconds(_producingTime);
        Produce();
    }
}
