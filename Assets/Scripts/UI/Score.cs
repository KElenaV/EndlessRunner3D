using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private PlayerCollision _player;
    [SerializeField] private TMP_Text _scoreDisplay;

    private int _score = 0;

    private void OnEnable()
    {
        _player.CakeCollected += OnCakeCollected;
    }

    private void OnDisable()
    {
        _player.CakeCollected -= OnCakeCollected;
    }

    private void OnCakeCollected(Cake cake)
    {
        _score += cake.Reward;
        _scoreDisplay.text = _score.ToString();
    }
}
