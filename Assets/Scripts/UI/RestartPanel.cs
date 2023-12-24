using System.Collections;
using TMPro;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    [SerializeField] private PlayerCollision _player;
    [SerializeField] private GameObject _restartPanel;
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private TMP_Text _distanceDisplay;
    [SerializeField] private Score _score;
    [SerializeField] private Distance _distance;

    private void OnEnable()
    {
        _player.Fell += OnFell;
    }

    private void OnDisable()
    {
        _player.Fell -= OnFell;
    }

    private void OnFell()
    {
        StartCoroutine(ActivateRestartPanel());
    }

    private IEnumerator ActivateRestartPanel()
    {
        yield return new WaitForSeconds(4);
        _restartPanel.SetActive(true);
        ShowDistance();
        ShowScore();
    }

    private void ShowDistance()
    {
        int distance = _distance.Value;
        _distanceDisplay.text = distance.ToString();
    }

    private void ShowScore()
    {
        int score = _score.Value;
        _scoreDisplay.text = score.ToString();
    }
}
