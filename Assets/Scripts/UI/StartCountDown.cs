using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StartCountDown : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private TMP_Text _countDown;
    [SerializeField] private GameObject _collectedDisplay;
    [SerializeField] private GameObject _distanceDisplay;
    [SerializeField] private GameObject _prestartSection;
    [SerializeField] private AudioClip _countSound;
    [SerializeField] private AudioClip _startGameSound;

    private int _count = 3;
    private string _goText = "GO!";
    private float _delay = 1;
    private WaitForSeconds _waitForSeconds;

    public event UnityAction<AudioClip> NextCount;

    private void Awake()
    {
        _startPanel.SetActive(true);
        _collectedDisplay.gameObject.SetActive(false);
        _distanceDisplay.gameObject.SetActive(false);
    }

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        while(_count > 0)
        {
            _countDown.gameObject.SetActive(true);
           
            yield return _waitForSeconds;
            
            _count--;
            _countDown.text = _count.ToString();
            _countDown.gameObject.SetActive(false);
            NextCount?.Invoke(_countSound);
        }

        _countDown.gameObject.SetActive(true);
        _countDown.text = _goText;
        
        yield return _waitForSeconds;

        _collectedDisplay.gameObject.SetActive(true);
        _distanceDisplay.gameObject.SetActive(true);
        NextCount?.Invoke(_startGameSound);
        Destroy(_startPanel);
        Destroy(_prestartSection);
    }
}
