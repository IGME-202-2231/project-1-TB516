using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;

    public void FireBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(_bulletPrefab, (transform.position + direction), Quaternion.identity, GameInfo.Manager.transform);
        bullet.transform.right = direction;
        bullet.tag = gameObject.tag;

        CollisionManager.Instance.AddProjectile(bullet.GetComponent<EntityCollider>());
    }
}
