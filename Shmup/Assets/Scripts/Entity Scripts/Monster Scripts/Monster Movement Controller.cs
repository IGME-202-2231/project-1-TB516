using UnityEngine;

public class MonsterMovementController : MonoBehaviour
{
    private const float _speed = 1.5f;
    private Vector3 _position;
    private Vector3 _velocity;

    void Start()
    {
        transform.right = Vector3.left;
        _position = transform.position;
    }

    void Update()
    {
        _velocity = transform.right + new Vector3(0, (GameInfo.Player.transform.position - transform.position).y * Random.Range(-6f, 10f), 0).normalized;
        _velocity = _speed * Time.deltaTime * _velocity.normalized;

        _position += _velocity;

        if (_position.x < -(GameInfo.CameraWidth / 2))
        {
            Destroy(gameObject);
        }

        transform.position = _position;
    }
}
