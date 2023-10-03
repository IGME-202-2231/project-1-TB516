using System.Collections;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    private enum PlayerState
    {
        Idle,
        Moving
    }

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private MovementController _movementController;
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

    // Update is called once per frame
    void Update()
    {
        switch (_movementController.Direction != Vector3.zero)
        {
            case true:
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
                break;

            case false:
                State = PlayerState.Idle;
                break;
        }
    }
}
