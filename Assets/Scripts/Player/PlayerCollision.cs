using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction<Cake> CakeCollected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Cake cake))
        {
            CakeCollected?.Invoke(cake);
            cake.gameObject.SetActive(false);
        }
    }
}
