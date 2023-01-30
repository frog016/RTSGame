using System.Collections;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    [SerializeField] private float _resetTime;

    private bool _isReady = true;

    public bool TryRestart()
    {
        if (!_isReady)
            return false;

        StartCoroutine(ResetCoroutine());
        return true;
    }

    private IEnumerator ResetCoroutine()
    {
        _isReady = false;
        yield return new WaitForSeconds(_resetTime);
        _isReady = true;
    }
}