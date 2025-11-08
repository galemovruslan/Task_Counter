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

    public event Action<int> Counted;

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
        Counted += action;
    }

    public void Unsubscribe(Action<int> action)
    {
        Counted -= action;
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
        var wait = new WaitForSeconds(_delay);

        while (_isRun)
        {
            yield return wait;

            ++_value;
            Counted?.Invoke(_value);
        }
    }
}
