using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private float _sidewayDirection;

    public float SidewayDirection => _sidewayDirection;

    public event UnityAction<float> MoveSideward;
    public event UnityAction Jump;

   public void OnSideMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MoveSideward?.Invoke(context.ReadValue<float>());
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump?.Invoke();
        }
    }
}
