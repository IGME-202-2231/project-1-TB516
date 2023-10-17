using UnityEngine;

public class EntityCollider : MonoBehaviour
{
    [SerializeField] float _radius = 2;

    public bool IsCollidingWith(EntityCollider entity)
    {
        return (transform.position - entity.transform.position).magnitude <= _radius + entity._radius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
