using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction<AudioClip> CakeCollected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Cake cake))
        {
            CakeCollected?.Invoke(cake.CollectedSound);
            cake.gameObject.SetActive(false);
        }
    }
}
