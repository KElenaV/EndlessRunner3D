using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed = 1;
    [SerializeField] private float _sidewardSpeed = 0;

    private PlayerInput _playerInput;
    private int _allPoints;
    private int _targetPoint;
    private float[] _xPoints = { -2.1f, 0f, 2.1f };
    private float _checkPointZ;
    private float _checkDistance = 80;

    public event UnityAction CrossedSection;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _allPoints = _xPoints.Length;
        _targetPoint = _xPoints.Length / 2;
        _checkPointZ = transform.position.z + _checkDistance;
        transform.position = new Vector3(_xPoints[_targetPoint], transform.position.y, transform.position.z);
    }

    private void OnEnable()
    {
        _playerInput.MoveSideward += OnMoveSideward;
    }

    private void OnDisable()
    {
        _playerInput.MoveSideward -= OnMoveSideward;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _forwardSpeed * Time.deltaTime);

        if(transform.position.z >= _checkPointZ)
        {
            Debug.Log(transform.position.z);
            _checkPointZ += _checkDistance;
            CrossedSection?.Invoke();
        }
    }

    private void OnMoveSideward(float direction)
    {
        _targetPoint = _targetPoint + (int)direction;

        if(_targetPoint >= _allPoints || _targetPoint < 0)
        {
            _targetPoint = Mathf.Clamp(_targetPoint, 0, _allPoints-1);
            return;
        }

        if (direction > 0)
            StartCoroutine(MoveRightTillPoint());
        else if (direction < 0)
            StartCoroutine(MoveLeftTillPoint());
    }

    private IEnumerator MoveRightTillPoint()
    {
        while(_xPoints[_targetPoint] > transform.position.x)
        {
            transform.Translate(Vector3.right * _sidewardSpeed * Time.deltaTime);
            float xPosition = Mathf.Clamp(transform.position.x, _xPoints[_targetPoint - 1], _xPoints[_targetPoint]);
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
            yield return null;
        }
    }

    private IEnumerator MoveLeftTillPoint()
    {
        while (_xPoints[_targetPoint] < transform.position.x)
        {
            transform.Translate(Vector3.left * _sidewardSpeed * Time.deltaTime);
            float xPosition = Mathf.Clamp(transform.position.x, _xPoints[_targetPoint], _xPoints[_targetPoint+1]);
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
            yield return null;
        }
    }
}
