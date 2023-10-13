using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private PlayerMovementController _movementController;
    [SerializeField] private WeaponController _weaponController;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        _movementController.Direction = ctx.ReadValue<Vector2>();
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _weaponController.FireBullet(_movementController.Direction);
        }
    }
}
