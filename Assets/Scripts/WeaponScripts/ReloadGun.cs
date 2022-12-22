using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadGun : MonoBehaviour
{
    [SerializeField] float _reloadTime;
    [SerializeField] WeaponAnimator _weaponAnimatorScript;
    [SerializeField] WeaponAmmo _weaponAmmo;
    [field: SerializeField] public bool reloading { get; private set; }

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
        reloading = false;
    }

    void OnDisable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().ReloadingGun -= OnReloadingGun;
    }

    void OnReloadingGun()
    {
        if (_weaponAmmo.EmptyAmmo == false)
        {
            if (reloading == false)
            {
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
        if (_weaponAmmo.EmptyAmmo == false)
        {
            if (_weaponAmmo.MagazineAmmo <= 0)
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
        yield return new WaitForSeconds(0.2f);
        _weaponAmmo.ReloadWeapon();
        reloading = false;
    }  
}
