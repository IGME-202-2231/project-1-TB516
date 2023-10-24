using UnityEngine;

public class BossSpawnActions : MonoBehaviour
{
    [SerializeField] private Vector3 _finalPos;
    private const float _speed = .5f;
    private Vector3 _direction;

    private void Start()
    {
        _direction = _finalPos - transform.position;
        transform.right.Normalize();
    }

    void Update()
    {
        if (transform.position.x <= _finalPos.x && transform.position.y >= _finalPos.y)
        {
            enabled = false;
            return;
        }
        transform.position += _direction * Time.deltaTime * _speed;
    }
}
