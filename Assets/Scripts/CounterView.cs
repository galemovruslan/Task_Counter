using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Counter))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private Text _label;

    private Counter _counter;

    private void Awake()
    {
        _counter = GetComponent<Counter>();    
    }

    private void OnEnable()
    {
        _counter.Subscribe(SetValue);
    }

    private void OnDisable()
    {
        _counter.Unsubscribe(SetValue);
    }

    private void SetValue(int value)
    {
        _label.text = $"{value}";
    }
}
