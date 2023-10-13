using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    public void FireBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity, StaticInfo.Manager.transform);
        bullet.GetComponent<ProjectileMovementController>().Direction = direction;
    }
}
