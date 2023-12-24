using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private PlayerCollision _player;
    [SerializeField] private TMP_Text _scoreDisplay;

    private int _value = 0;

    public int Value => _value;

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
        _value += cake.Reward;
        _scoreDisplay.text = _value.ToString();
    }
}
