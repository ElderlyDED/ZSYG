using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargaredGunShot : MonoBehaviour
{
    Camera _fpsCam;
    [SerializeField] float _chargaredTime;
    [SerializeField] float _maxCharge;
    [SerializeField] int _damage;
    [SerializeField] float _range;
    [SerializeField] FlashScript _flashScript;
    [SerializeField] ShotImpactScript _shotImpactScript;
    [SerializeField] float _delayShot;
    [SerializeField] bool _readyShot;
    PlayerInput _playerInputScript;
    [SerializeField] WeaponAnimator _weaponAnimatorScript;
    void Start()
    {
        _fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _flashScript = gameObject.GetComponent<FlashScript>();
        _shotImpactScript = gameObject.GetComponent<ShotImpactScript>();
        _weaponAnimatorScript = gameObject.GetComponent<WeaponAnimator>();
    }

    private void OnEnable()
    {
        _playerInputScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        _playerInputScript.PressedFire += OnPressedFired;
        _playerInputScript.OffPressedFire += NotPressedFired;
    }

    private void OnDisable()
    {
        _playerInputScript.PressedFire -= OnPressedFired;
        _playerInputScript.OffPressedFire -= NotPressedFired;
    }

    void OnPressedFired()
    {
        if (_readyShot == true)
        {
            _chargaredTime += 2 * Time.deltaTime;
            if (_chargaredTime > _maxCharge)
            {
                NotPressedFired();
                _chargaredTime = 0f;
                _readyShot = false;
                StartCoroutine(SwitcherReadyShot());
            }
        }  
    }

    void NotPressedFired()
    {
        if (_readyShot == true)
        {
            int _chargaredDamage = _damage + (_damage * (int)_chargaredTime);
            _chargaredTime = 0f;
            RaycastHit hit;
            _flashScript.PlayFlash();
            _weaponAnimatorScript.GunShotAnimation();
            if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out hit, _range))
            {
                Debug.Log(hit.transform.name);
                EnemyHealt _eh = hit.transform.GetComponent<EnemyHealt>();
                if (_eh != null)
                {
                    gameObject.GetComponent<DamageEnemy>().GetDamage(_eh, _chargaredDamage);
                }
                _shotImpactScript.SpawnImpact(hit.point, Quaternion.LookRotation(hit.normal));
            }
            _readyShot = false;
            StartCoroutine(SwitcherReadyShot());
        }
    }

    IEnumerator SwitcherReadyShot()
    {
        yield return new WaitForSeconds(_delayShot);
        _readyShot = true;
    }
}
