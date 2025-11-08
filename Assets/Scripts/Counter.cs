using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const int ToggleButton = 0;

    private float _delay = 0.5f;
    private bool _isRun = false;
    private int _value = 0;
    private Coroutine _coroutine;

    private event Action<int> _counted;

    private void Update()
    {
        if (Input.GetMouseButtonDown(ToggleButton))
        {
            _isRun = !_isRun;
            ToggleCounter();
        }
    }

    public void Subscribe(Action<int> action)
    {
        _counted += action;
    }

    public void Unsubscribe(Action<int> action)
    {
        _counted -= action;
    }

    private void ToggleCounter()
    {
        if (_isRun)
        {
            Debug.Log("Старт");
            _coroutine = StartCoroutine(nameof(Counting));
        }
        else
        {
            Debug.Log("Стоп");
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Counting()
    {
        while (_isRun)
        {
            yield return new WaitForSeconds(_delay);

            ++_value;
            _counted?.Invoke(_value);
        }
    }
}
