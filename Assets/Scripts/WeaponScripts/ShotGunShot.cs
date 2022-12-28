using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShot : MonoBehaviour
{
    Camera _fpsCam;
    [SerializeField] int _bulletDamage;
    [SerializeField] float _range;
    [SerializeField] float _fireRate;
    [SerializeField] float _scatter;
    [SerializeField] int _bulletCount;
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
        if (_weaponAmmo.EmptyAmmo == false)
        {
            if (_reloadGun.reloading == false)
            {
                if (Time.time >= _nextTimeToFire)
                {
                    _nextTimeToFire = Time.time + 1f / _fireRate;
                    _weaponAmmo.ShotMinusAmmo();
                    RaycastHit hit;
                    _flashScript.PlayFlash();
                    _weaponAnimatorScript.GunShotAnimation();
                    for (int _bCount = _bulletCount; _bCount > 0; _bCount--)
                    {
                        Vector3 _direction = _fpsCam.transform.forward;
                        Vector3 _spread = new Vector3();
                        _spread += _fpsCam.transform.up * Random.Range(-_scatter, _scatter);
                        _spread += _fpsCam.transform.right * Random.Range(-_scatter, _scatter);
                        _direction += _spread.normalized * Random.Range(0f, 0.2f);
                        if (Physics.Raycast(_fpsCam.transform.position, _direction, out hit, _range))
                        {
                            Debug.Log(hit.transform.name);
                            EnemyHealth _eh = hit.transform.GetComponent<EnemyHealth>();
                            if (_eh != null)
                            {
                                gameObject.GetComponent<DamageEnemy>().GetDamage(_eh, _bulletDamage);
                            }
                            _shotImpactScript.SpawnImpact(hit.point, Quaternion.LookRotation(hit.normal));
                        }
                    }

                }
            }
        }
    }
}
