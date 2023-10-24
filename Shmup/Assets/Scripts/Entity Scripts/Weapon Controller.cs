using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] EntityCollider _bulletPrefabCollider;
    [SerializeField] EntityCollider _currentCollider;

    public void FireBullet(Vector3 direction)
    {
        EntityCollider bullet = Instantiate(_bulletPrefabCollider, (transform.position + (direction * _currentCollider.Radius)), Quaternion.identity, GameInfo.CollisionManager.transform);
        bullet.gameObject.transform.right = direction;
        bullet.gameObject.tag = gameObject.tag + "Projectile";

        GameInfo.CollisionManager.AddProjectile(bullet);
    }
}
