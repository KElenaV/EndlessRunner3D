using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 3;
    [SerializeField] private float _sidewardSpeed = 4;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();

        StayInBounds();
    }

    private void Move()
    {
        Vector3 forwardMovement = Vector3.forward * _forwardSpeed * Time.deltaTime;
        Vector3 sidewardMovement = Vector3.right * _playerInput.SidewayDirection * _sidewardSpeed * Time.deltaTime;
        transform.Translate(forwardMovement + sidewardMovement);
    }

    private void StayInBounds()
    {
        float xPosition = Mathf.Clamp(transform.position.x, LevelBoundary.LeftBound, LevelBoundary.RightBound);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
