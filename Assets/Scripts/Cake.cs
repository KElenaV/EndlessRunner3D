using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] private AudioClip _collectedSound;

    public AudioClip CollectedSound => _collectedSound;
}
