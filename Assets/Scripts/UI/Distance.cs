using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Distance : MonoBehaviour
{
    [SerializeField] private TMP_Text _distanceDisplay;
    [SerializeField] private Mover _player;
    [SerializeField] private float _delay = 5;

    private int _value = 0;
    private int _speedChangaDistance = 10;
    private int _distanceLevel = 1;
    private bool _isIncrease = true;

    public event UnityAction ChangeSpeed;

    public int Value => _value;

    private void Start()
    {
        StartCoroutine(IncreaseDistance());
    }

    private IEnumerator IncreaseDistance()
    {
        while (_isIncrease)
        {
            float velocity = _delay / _player.Speed;
            yield return new WaitForSeconds(velocity);
            _value++;
            _distanceDisplay.text = _value.ToString();

            if(_value / (_speedChangaDistance * _distanceLevel) >= 1)
            {
                ChangeDistanceParametres();
                ChangeSpeed?.Invoke();
            }
        }
    }

    private void ChangeDistanceParametres()
    {
        _distanceLevel++;
        _speedChangaDistance *= 2;

    }

    internal void Stop() => _isIncrease = false;
}
