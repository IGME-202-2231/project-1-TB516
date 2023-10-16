using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;

    public void FireBullet(Vector3 direction)
    {
        if (!GameInfo.GCDReady) return;

        GameObject bullet = Instantiate(_bullet, (transform.position + direction), Quaternion.identity, GameInfo.Manager.transform);
        bullet.transform.right = direction;

        StartCoroutine(GameInfo.StartGCD());
    }
}
