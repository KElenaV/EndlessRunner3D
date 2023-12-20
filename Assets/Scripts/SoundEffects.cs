using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    [SerializeField] private PlayerCollision _player;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.CakeCollected += OnCakeCollected;
    }

    private void OnDisable()
    {
        _player.CakeCollected -= OnCakeCollected;
    }

    private void OnCakeCollected(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio);
    }
}
