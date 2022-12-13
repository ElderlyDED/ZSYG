using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGun : MonoBehaviour
{
    [SerializeField] float _reloadTime;
    [SerializeField] WeaponAnimator _weaponAnimatorScript;
    [SerializeField] WeaponAmmo _weaponAmmo;
    public bool reloading { get; private set; }

    private void Start()
    {
        _weaponAnimatorScript = gameObject.GetComponent<WeaponAnimator>();
        _weaponAmmo = gameObject.GetComponent<WeaponAmmo>();
    }

    void Update()
    {
        AutoReloadingGun();
    }

    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().ReloadingGun += OnReloadingGun;
    }

    void OnDisable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().ReloadingGun -= OnReloadingGun;
    }

    void OnReloadingGun()
    {
        if (_weaponAmmo.emptyAmmo == false)
        {
            if (reloading == false)
            {
                _weaponAmmo.ReloadWeapon();
                StartCoroutine(AnimationReloading());
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

    void AutoReloadingGun()
    {
        if (_weaponAmmo.emptyAmmo == false)
        {
            if (_weaponAmmo.magazineAmmo <= 0)
            {
                OnReloadingGun();
            }
        }
        else
        {
            return;
        }
        
    }

    IEnumerator AnimationReloading()
    {
        reloading = true;
        _weaponAnimatorScript.GunDownAnimation();
        yield return new WaitForSeconds(_reloadTime);
        _weaponAnimatorScript.GunUpAnimation();
        reloading = false;
    }  
}
