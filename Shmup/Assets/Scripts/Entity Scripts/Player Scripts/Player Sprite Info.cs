using UnityEngine;

public class PlayerSpriteInfo : MonoBehaviour
{
    private enum PlayerState
    {
        Idle,
        Moving
    }

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private PlayerMovementController _movementController;
    [SerializeField] private Animator _animator;
    private PlayerState _state = PlayerState.Idle;

    private PlayerState State
    {
        set
        {
            _state = value;

            switch (_state)
            {
                case PlayerState.Idle:
                    _animator.Play("Idle");
                    break;
                case PlayerState.Moving:
                    _animator.Play("Move");
                    break;
            }
        }
    }

    void Update()
    {
        if (_movementController.Direction != Vector3.zero)
        {
            State = PlayerState.Moving;

            _animator.SetFloat("xDirection", _movementController.Direction.x);
            _animator.SetFloat("yDirection", _movementController.Direction.y);

            switch (_movementController.Direction.x)
            {
                case > 0:
                    _renderer.flipX = false;
                    break;
                case < 0:
                    _renderer.flipX = true;
                    break;
            }
        }
        else
        {
            State = PlayerState.Idle;
        }
    }
}
