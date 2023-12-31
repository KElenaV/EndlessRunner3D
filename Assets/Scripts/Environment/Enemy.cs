using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed = 0.5f;

    private float _direction = 1;
    private float _startPointZ;
    private float _endPointZ;
    private bool _canMove = true;

    private Animator _animator;
    private int _isHit = Animator.StringToHash("IsHit");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _startPointZ = _startPoint.position.z;
        _endPointZ = _endPoint.position.z;
    }

    private void Update()
    {
        if (_canMove)
        {
            transform.Translate(Vector3.forward * _direction * _speed * Time.deltaTime);

            float zPosition = Mathf.Clamp(transform.position.z, _startPointZ, _endPointZ);
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);

            if (transform.position.z == _startPointZ || transform.position.z == _endPointZ)
                ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _direction *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, -transform.localScale.z);
    }

    public void Stop()
    {
        _canMove = false;
        _animator.SetBool(_isHit, true);
    }
}
