using System.Collections;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;

    private bool _globalCooldownOne = false;
    private bool _globalCooldownTwo = false;

    private void Start()
    {
        StartCoroutine(StartGCDOne());
        StartCoroutine(StartGCDTwo());
    }

    void Update()
    {
        Vector3 direction = (GameInfo.Player.transform.position - transform.position).normalized;
            
        if (_globalCooldownOne && Random.value >= .5f)
        {
            _weaponController.FireBullet(direction);
            StartCoroutine(StartGCDOne());
        }

        if (_globalCooldownTwo && Random.value >= .5f)
        {
            _weaponController.FireBullet(direction);
            StartCoroutine(StartGCDTwo());
        }
    }

    private IEnumerator StartGCDOne()
    {
        _globalCooldownOne = false;

        yield return new WaitForSeconds(.75f);

        _globalCooldownOne = true;
    }

    private IEnumerator StartGCDTwo()
    {
        _globalCooldownTwo = false;

        yield return new WaitForSeconds(.75f);

        _globalCooldownTwo = true;
    }
}
