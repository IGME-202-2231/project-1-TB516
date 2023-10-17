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
        if (GameInfo.GCDReady && _movementController.Direction == Vector3.zero)
        {
            _weaponController.FireBullet(Vector3.right);
            StartCoroutine(GameInfo.StartGCD());
        }
        else if (GameInfo.GCDReady)
        {
            _weaponController.FireBullet(_movementController.Direction);
            StartCoroutine(GameInfo.StartGCD());
        }
    }
}
