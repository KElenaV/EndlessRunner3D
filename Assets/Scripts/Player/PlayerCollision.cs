using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction<Cake> CakeCollected;
    public event UnityAction Fell;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Cake cake))
        {
            CakeCollected?.Invoke(cake);
            cake.gameObject.SetActive(false);
        }
        else if(other.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Fell?.Invoke();
        }
        else if(other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Stop();
            Fell?.Invoke();
        }
    }
}
