using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    [SerializeField] private PlayerCollision _player;
    [SerializeField] private StartCountDown _countDown;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.CakeCollected += OnCakeCollected;
        _countDown.NextCount += OnNextCount;
    }

    private void OnDisable()
    {
        _player.CakeCollected -= OnCakeCollected;
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
}
