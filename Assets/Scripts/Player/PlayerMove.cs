using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
