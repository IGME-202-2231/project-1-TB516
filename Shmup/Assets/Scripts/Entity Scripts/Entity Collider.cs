using UnityEngine;

public class EntityCollider : MonoBehaviour
{
    [SerializeField] protected float _circleRadius = 2;

    [SerializeField] protected Vector3 _circleHitboxOffset;

    protected Vector3 _circlePos;

    public Vector3 CirclePos => _circlePos;

    public float Radius => _circleRadius;

    protected void Start()
    {
        _circlePos = transform.position - _circleHitboxOffset;
    }

    protected void Update()
    {
        _circlePos = transform.position - _circleHitboxOffset;
    }

    public virtual bool IsCollidingWith(EntityCollider entity)
    {
        return (_circlePos - entity._circlePos).magnitude <= _circleRadius + entity._circleRadius;
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_circlePos, _circleRadius);
    }

    protected void OnDestroy()
    {
        switch (tag)
        {
            case "enemy":
                GameInfo.Score++;
                GameInfo.Spawner.MonstersKilled++;
                break;
            case "oobMonster":
                GameInfo.Score--;
                GameInfo.Spawner.MonstersSpawned--;
                break;
        }
    }
}
