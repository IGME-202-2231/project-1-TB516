using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private const float _speed = 4;
    private Vector3 _direction;
    private Vector3 _position;
    private Vector3 _velocity;

    public Vector3 Direction
    {
        get { return _direction; }
        set { _direction = value.normalized; }
    }

    void Update()
    {
        _velocity = _speed * Time.deltaTime * _direction;
        _position += _velocity;

        #region Screen border collision
        if (_position.x > GameInfo.CameraWidth / 2)
        {
            _position.x = GameInfo.CameraWidth / 2;
        }
        else if (_position.x < -(GameInfo.CameraWidth / 2))
        {
            _position.x = -GameInfo.CameraWidth / 2;
        }

        if (_position.y > GameInfo.CameraHeight / 2)
        {
            _position.y = GameInfo.CameraHeight / 2;
        }
        else if (_position.y < -(GameInfo.CameraHeight / 2))
        {
            _position.y = -GameInfo.CameraHeight / 2;
        }
        #endregion

        transform.position = _position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + _direction*2);
    }
}
