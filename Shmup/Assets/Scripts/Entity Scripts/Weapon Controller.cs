using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] EntityCollider _bulletPrefabCollider;

    public void FireBullet(Vector3 direction)
    {
        EntityCollider bullet = Instantiate(_bulletPrefabCollider, (transform.position + direction), Quaternion.identity, GameInfo.Manager.transform);
        bullet.gameObject.transform.right = direction;
        bullet.gameObject.tag = gameObject.tag;

        CollisionManager.Instance.AddProjectile(bullet);
    }
}
