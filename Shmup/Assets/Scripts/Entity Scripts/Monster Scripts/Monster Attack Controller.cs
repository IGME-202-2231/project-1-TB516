using System.Collections;
using UnityEngine;

public class MonsterAttackController : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;
    private bool _globalCooldownUp = true;

    void Update()
    {
        if (_globalCooldownUp && Random.value >= .75f)
        {
            _weaponController.FireBullet(transform.right);
            StartCoroutine(StartGCD());
        }
    }

    private IEnumerator StartGCD()
    {
        _globalCooldownUp = false;

        yield return new WaitForSeconds(5f);

        _globalCooldownUp = true;
    }
}
