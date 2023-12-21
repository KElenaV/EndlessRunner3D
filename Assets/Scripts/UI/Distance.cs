using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Distance : MonoBehaviour
{
    [SerializeField] private TMP_Text _distanceDisplay;
    [SerializeField] private Mover _player;
    [SerializeField] private float _delay = 10;

    private int _distance = 0;
    private int _speedChangaDistance = 5;
    private int _distanceLevel = 1;

    public event UnityAction ChangeSpeed; 

    private void Start()
    {
        StartCoroutine(IncreaseDistance());
    }

    private IEnumerator IncreaseDistance()
    {
        while (true)
        {
            float velocity = _delay / _player.Speed;
            yield return new WaitForSeconds(velocity);
            _distance++;
            _distanceDisplay.text = _distance.ToString();

            if(_distance / (_speedChangaDistance * _distanceLevel) >= 1)
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
}
