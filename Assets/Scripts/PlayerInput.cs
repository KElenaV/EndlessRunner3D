using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private float _sidewayDirection;

    public float SidewayDirection => _sidewayDirection;

   public void OnSideMove(InputAction.CallbackContext context)
    {
        _sidewayDirection = context.ReadValue<float>();
    }
}
