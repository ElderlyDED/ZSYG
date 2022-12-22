using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGunShot : MonoBehaviour
{
    Camera _fpsCam;
    public int grenadeDamage;
    [SerializeField] GameObject _grenade;
    [SerializeField] Transform _grenadeSpawnPoint;
    [SerializeField] float _shotForce;
    [SerializeField] float _shotUpForce;
    [SerializeField] float _fireRate;
    float _nextTimeToFire = 0f;
    [SerializeField] FlashScript _flashScript;
    [SerializeField] WeaponAnimator _weaponAnimatorScript;
    [SerializeField] WeaponAmmo _weaponAmmo;
    [SerializeField] ReloadGun _reloadGun;
    void Start()
    {
        _fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _flashScript = gameObject.GetComponent<FlashScript>();
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
                    _flashScript.PlayFlash();
                    GameObject _grenadeObj = Instantiate(_grenade, _grenadeSpawnPoint.position, _fpsCam.transform.rotation);
                    Vector3 _force = _fpsCam.transform.forward * _shotForce + transform.up * _shotUpForce;
                    _grenadeObj.GetComponent<Rigidbody>().AddForce(_force, ForceMode.Impulse);
                    _weaponAnimatorScript.GunShotAnimation();
                }
            }
        }
    }
}
