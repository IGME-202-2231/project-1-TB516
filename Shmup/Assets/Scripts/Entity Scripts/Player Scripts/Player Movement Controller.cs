using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    const float _speed = 4;
    Vector3 _direction;
    Vector3 _position;
    Vector3 _velocity;

    public Vector3 Direction
    {
        get { return _direction; }
        set { _direction = value.normalized; }
    }

    void Update()
    {
        _velocity = _speed * _direction * Time.deltaTime;
        _position += _velocity;

        #region Screen border collision
        if (_position.x > StaticInfo.CameraWidth / 2)
        {
            _position.x = StaticInfo.CameraWidth / 2;
        }
        else if (_position.x < -(StaticInfo.CameraWidth / 2))
        {
            _position.x = -StaticInfo.CameraWidth / 2;
        }

        if (_position.y > StaticInfo.CameraHeight / 2)
        {
            _position.y = StaticInfo.CameraHeight / 2;
        }
        else if (_position.y < -(StaticInfo.CameraHeight / 2))
        {
            _position.y = -StaticInfo.CameraHeight / 2;
        }
        #endregion

        transform.position = _position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + _direction*2);
    }
}
