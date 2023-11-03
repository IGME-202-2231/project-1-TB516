using UnityEngine;
using UnityEngine.UI;

public class BossCollider : CircleCollider
{
    [SerializeField] private float _maxHp;

    [SerializeField] private Vector3 _rectHitboxOffset;

    [SerializeField] private Vector3 _rectHitboxSize;

    [SerializeField] private Slider _healthBarUISlider;

    private Rect _rectHitbox;

    private float _hp;

    public float Hp
    {
        get => _hp;
        set
        {
            _hp = value;
        }
    }

    private new void Start()
    {
        _hp = _maxHp;

        base.Start();

        _rectHitbox = new(transform.position.x - _rectHitboxOffset.x, transform.position.y - _rectHitboxOffset.y, _rectHitboxSize.x, _rectHitboxSize.y);

        _healthBarUISlider.gameObject.SetActive(true);
    }

    private new void Update()
    {
        base.Update();

        _healthBarUISlider.value = _hp / _maxHp;

        _rectHitbox.position = transform.position - _rectHitboxOffset * 2;
        _rectHitbox.size = _rectHitboxSize;

        if (_hp <= 0) GameStateManager.GameWin();
    }

    public override bool IsCollidingWith(CircleCollider entity)
    {
        return base.IsCollidingWith(entity) || RectCollisionCheck(entity);
    }

    private bool RectCollisionCheck(CircleCollider entity)
    {
        float deltaX = entity.CirclePos.x - Mathf.Max(_rectHitbox.x, Mathf.Min(entity.CirclePos.x, _rectHitbox.x + _rectHitbox.width));
        float deltaY = entity.CirclePos.y - Mathf.Max(_rectHitbox.y - _rectHitbox.height, Mathf.Min(entity.CirclePos.y, _rectHitbox.y + _rectHitbox.height));

        return (deltaX * deltaX) + (deltaY * deltaY) < entity.Radius * entity.Radius;
    }

    private new void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireCube(new((_rectHitbox.x + _rectHitbox.width / 2), (_rectHitbox.y - _rectHitbox.height / 2)), _rectHitbox.size);
        Gizmos.DrawSphere(_rectHitbox.position, .1f);
    }
}
