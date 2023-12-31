using System.Collections;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private PlayerInput _player;
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;

    private bool _isjump = false;
    private bool _comingDown = false;
    private readonly string JumpTrigger = "JumpTrigger";

    private void OnEnable()
    {
        _player.Jump += TryJump;
    }

    private void OnDisable()
    {
        _player.Jump -= TryJump;
    }

    private void Update()
    {
        if (_isjump)
        {
            if (_comingDown == false)
                transform.Translate(Vector3.up * Time.deltaTime * 3);

            if (_comingDown == true)
                transform.Translate(Vector3.down * Time.deltaTime * 3);
        }
    }

    private void TryJump()
    {
        if (_isjump == false && _mover.IsWithinBounds())
        {
            _isjump = true;
            _animator.SetTrigger(JumpTrigger);
            StartCoroutine(JumpSequence());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        _isjump = false;
        _comingDown = false;
    }

    private IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        _comingDown = true;
    }
}
