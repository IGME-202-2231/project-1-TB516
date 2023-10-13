using UnityEngine;

public class ProjectileMovementController : MonoBehaviour
{
    const float _speed = 5f;
    Vector3 _direction;
    Vector3 _position;
    Vector3 _velocity;

    public Vector3 Direction
    {
        get { return _direction; }
        set 
        {
            if (value != Vector3.zero) _direction = value.normalized;
            else _direction = Vector3.right;
        }
    }

    private void Start()
    {
        _position = transform.position;
    }

    void Update()
    {
        _velocity = _direction * _speed * Time.deltaTime;

        _position += _velocity;

        if (_position.x > StaticInfo.CameraWidth / 2 || _position.x < -(StaticInfo.CameraWidth / 2) || _position.y > StaticInfo.CameraHeight / 2 || _position.y < -(StaticInfo.CameraHeight / 2))
        {
            Destroy(gameObject);
        }

        transform.position = _position;
    }
}
