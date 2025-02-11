using UnityEngine;
using UnityEngine.UI;
public class LonelinessMeter : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private Table _table;
    [SerializeField] private float _decreasingSpeed;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _deadValue;

    [SerializeField] private EndGameScreenController _endGameScreenController;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _maxValue;
        _slider.value = 0;

        _table.OnPerformed += DecreaseValue;
    }
    private void Update()
    {
        _slider.value += _decreasingSpeed * Time.deltaTime;
        if(_slider.value >= _deadValue)
        {
            _endGameScreenController.ShowDeadScreen();
        }
    }
    private void DecreaseValue()
    {
        _slider.value = 0;
    }
}
