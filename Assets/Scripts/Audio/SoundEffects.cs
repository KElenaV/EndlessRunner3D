using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    [SerializeField] private PlayerCollision _player;
    [SerializeField] private StartCountDown _countDown;
    [SerializeField] private AudioClip _playerFell;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.CakeCollected += OnCakeCollected;
        _player.Fell += OnFell;
        _countDown.NextCount += OnNextCount;
    }
    
    private void OnDisable()
    {
        _player.CakeCollected -= OnCakeCollected;
        _player.Fell -= OnFell;
        _countDown.NextCount -= OnNextCount;
    }

    private void OnCakeCollected(Cake cake)
    {
        _audioSource.PlayOneShot(cake.CollectedSound);
    }

    private void OnNextCount(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio);
    }

    private void OnFell()
    {
        _audioSource.PlayOneShot(_playerFell);
    }

}
