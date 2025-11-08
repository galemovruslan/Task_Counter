using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private const int LeftMuoseButtomIndex = 0;

    [SerializeField] private Text _label;

    private float _delay = 0.5f;
    private bool _isRun = false;
    private int _value = 0;
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMuoseButtomIndex))
        {
            _isRun = !_isRun;
            ToggleCounter();
        }
    }

    private void ToggleCounter()
    {
        if (_isRun)
        {
            Debug.Log("Старт");
            _coroutine = StartCoroutine(nameof(Count));
        }
        else
        {
            Debug.Log("Стоп");
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Count()
    {
        while (_isRun)
        {
            yield return new WaitForSeconds(_delay);

            ++_value;
            _label.text = $"{_value}";
        }
    }
}
