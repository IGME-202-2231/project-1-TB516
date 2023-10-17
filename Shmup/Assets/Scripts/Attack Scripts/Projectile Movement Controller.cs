using UnityEngine;

public class ProjectileMovementController : MonoBehaviour
{
    const float _speed = 5f;
    Vector3 _position;
    Vector3 _velocity;
    [SerializeField] EntityCollider _collider;

    private void Start()
    {
        _position = transform.position;
    }

    void Update()
    {
        _velocity = transform.right * _speed * Time.deltaTime;

        _position += _velocity;

        if (_position.x > GameInfo.CameraWidth / 2 || _position.x < -(GameInfo.CameraWidth / 2) || _position.y > GameInfo.CameraHeight / 2 || _position.y < -(GameInfo.CameraHeight / 2))
        {
            CollisionManager.Instance.MarkToRemove(_collider);
            Destroy(gameObject);
        }

        transform.position = _position;
    }
}
