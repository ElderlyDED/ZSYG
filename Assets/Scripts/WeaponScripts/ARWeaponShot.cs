using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARWeaponShot : MonoBehaviour
{
    Camera _fpsCam;
    [SerializeField] int _bulletDamage;
    [SerializeField] float _range;
    [SerializeField] float _fireRate;
    float _nextTimeToFire = 0f;
    [SerializeField] FlashScript _flashScript;
    [SerializeField] ShotImpactScript _shotImpactScript;
    [SerializeField] WeaponAnimator _weaponAnimatorScript;
    [SerializeField] WeaponAmmo _weaponAmmo;
    [SerializeField] ReloadGun _reloadGun;
    void Start()
    {
        _fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _flashScript = gameObject.GetComponent<FlashScript>();
        _shotImpactScript = gameObject.GetComponent<ShotImpactScript>();
        _weaponAnimatorScript = gameObject.GetComponent<WeaponAnimator>();
        _weaponAmmo = gameObject.GetComponent<WeaponAmmo>();
        _reloadGun = gameObject.GetComponent<ReloadGun>();
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().Fired += OnFired;
    }

    private void OnDisable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().Fired -= OnFired;
    }

    private void OnFired()
    {
        if (_weaponAmmo.emptyAmmo == false)
        {
            if (_reloadGun.reloading == false)
            {
                if (Time.time >= _nextTimeToFire)
                {
                    _nextTimeToFire = Time.time + 1f / _fireRate;
                    RaycastHit hit;
                    _weaponAmmo.ShotMinusAmmo();
                    _flashScript.PlayFlash();
                    _weaponAnimatorScript.GunShotAnimation();
                    if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out hit, _range))
                    {
                        Debug.Log(hit.transform.name);
                        EnemyHealt _eh = hit.transform.GetComponent<EnemyHealt>();
                        if (_eh != null)
                        {
                            gameObject.GetComponent<DamageEnemy>().GetDamage(_eh, _bulletDamage);
                        }
                        _shotImpactScript.SpawnImpact(hit.point, Quaternion.LookRotation(hit.normal));
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
}
