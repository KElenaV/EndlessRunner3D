using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed = 0.5f;

    private float _direction = 1;
    private float _startPointZ;
    private float _endPointZ;

    private void Start()
    {
        _startPointZ = _startPoint.position.z;
        _endPointZ = _endPoint.position.z;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _direction * _speed * Time.deltaTime);

        float zPosition = Mathf.Clamp(transform.position.z, _startPointZ, _endPointZ);
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);

        if (transform.position.z == _startPointZ || transform.position.z == _endPointZ)
            ChangeDirection();
    }

    private void ChangeDirection()
    {
        _direction *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, -transform.localScale.z);
    }
}
