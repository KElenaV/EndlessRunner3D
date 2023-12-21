using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] private int _reward = 1;
    [SerializeField] private AudioClip _collectedSound;

    public int Reward => _reward;
    public AudioClip CollectedSound => _collectedSound;
}
