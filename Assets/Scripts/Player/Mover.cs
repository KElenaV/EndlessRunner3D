using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(PlayerInput))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 1;
    [SerializeField] private float _sidewardSpeed = 0;
    [SerializeField] private Distance _distance;

    private PlayerInput _playerInput;
    private PlayerCollision _playerCollision;
    private int _pointsCount;
    private int _targetPointIndex;
    private float[] _xPoints = { -2.1f, 0f, 2.1f };
    private float _checkPointZ = -18;
    private float _checkDistance = 80;
    private float _startPoint = -20;
    private bool _run = true;

    public event UnityAction CrossedSection;

    public float Speed => _forwardSpeed;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerCollision = GetComponent<PlayerCollision>();
        _pointsCount = _xPoints.Length;
        _targetPointIndex = _xPoints.Length / 2;
        _checkPointZ += _checkDistance;
        SetPosition(_xPoints[_targetPointIndex]);
    }

    private void OnEnable()
    {
        _playerInput.MoveSideward += OnMoveSideward;
        _playerCollision.Fell += OnFell;
        _distance.ChangeSpeed += OnChangeSpeed;
    }

    private void OnDisable()
    {
        _playerInput.MoveSideward -= OnMoveSideward;
        _playerCollision.Fell -= OnFell;
        _distance.ChangeSpeed -= OnChangeSpeed;
    }

    private void Update()
    {
        if (_run)
        {
            MoveForward();
            CheckSectionCrossing();
        }
    }

    private void OnMoveSideward(float direction)
    {
        if (_run && IsWithinBounds())
        {
            _targetPointIndex += (int)direction;

            if (_targetPointIndex >= _pointsCount || _targetPointIndex < 0)
            {
                _targetPointIndex = Mathf.Clamp(_targetPointIndex, 0, _pointsCount - 1);
                return;
            }

            if (direction > 0)
                StartCoroutine(MoveRightTillPoint());
            else if (direction < 0)
                StartCoroutine(MoveLeftTillPoint());
        }
    }

    private IEnumerator MoveRightTillPoint()
    {
        while (_xPoints[_targetPointIndex] > transform.position.x)
        {
            transform.Translate(Vector3.right * _sidewardSpeed * Time.deltaTime);
            float xPosition = Mathf.Clamp(transform.position.x, _xPoints[_targetPointIndex - 1], _xPoints[_targetPointIndex]);
            SetPosition(xPosition);

            yield return null;
        }
    }

    private IEnumerator MoveLeftTillPoint()
    {
        while (_xPoints[_targetPointIndex] < transform.position.x)
        {
            transform.Translate(Vector3.left * _sidewardSpeed * Time.deltaTime);
            float xPosition = Mathf.Clamp(transform.position.x, _xPoints[_targetPointIndex], _xPoints[_targetPointIndex + 1]);
            SetPosition(xPosition);

            yield return null;
        }
    }

    private void MoveForward() => transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);

    private void CheckSectionCrossing()
    {
        if (transform.position.z >= _checkPointZ)
        {
            _checkPointZ += _checkDistance;
            CrossedSection?.Invoke();
        }
    }

    private void SetPosition(float xPosition) => transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    
    private bool IsWithinBounds() => transform.position.z >= _startPoint;

    private void OnChangeSpeed() => _forwardSpeed++;

    private void OnFell()
    {
        _run = false;
        _distance.Stop();
    }
}
