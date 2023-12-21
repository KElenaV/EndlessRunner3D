using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    [SerializeField] private Distance _distance;
    [SerializeField] private AudioSource _audio;

    private void OnEnable()
    {
        _distance.ChangeSpeed += OnChangeSpeed;
    }

    private void OnDisable()
    {
        _distance.ChangeSpeed -= OnChangeSpeed;
    }

    private void OnChangeSpeed()
    {
        _audio.pitch += 0.02f;
    }
}
