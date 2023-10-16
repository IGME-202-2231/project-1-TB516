using UnityEngine;

public class MonsterMovementController : MonoBehaviour
{
    private const float _speed = .5f;
    private Vector3 _position;
    private Vector3 _velocity;

    void Start()
    {
        transform.right = Vector3.left;
        _position = transform.position;
    }

    void Update()
    {
        _velocity = transform.right + new Vector3(0, (GameInfo.Player.transform.position - transform.position).y * Random.Range(-1.5f, 3f), 0).normalized;
        _velocity = _speed * Time.deltaTime * _velocity.normalized;

        _position += _velocity;

        transform.position = _position;
    }
}
