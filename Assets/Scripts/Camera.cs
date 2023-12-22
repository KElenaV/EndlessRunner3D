using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Camera : MonoBehaviour
{
    [SerializeField] private PlayerCollision _collision;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
    }

    private void OnEnable()
    {
        _collision.Fell += OnFell;
    }

    private void OnDisable()
    {
        _collision.Fell -= OnFell;
    }

    private void OnFell()
    {
        _animator.enabled = true;
    }
}
