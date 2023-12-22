using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerCollision _playerCollision;

    private Animator _animator;
    private int _deadHash = Animator.StringToHash("Dead");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerCollision.Fell += OnFell;
    }

    private void OnDisable()
    {
        _playerCollision.Fell -= OnFell;
    }

    private void OnFell()
    {
        _animator.SetTrigger(_deadHash);
    }
}
