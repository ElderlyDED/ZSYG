using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    [SerializeField] int _magazineSize;
    public int magazineAmmo;
    public bool emptyAmmo { get; private set; }
    [SerializeField] int _allAmmo;
    [SerializeField] bool _notMagazine;
    [SerializeField] bool _infAllAmmo;

    void Update()
    {
        CheckMagazinAmmo();
    }

    public void ShotMinusAmmo()
    {
        if (_notMagazine == true)
        {
            _allAmmo--;
        }
        else
        {
            magazineAmmo--;
        } 
   
    }

    public void ReloadWeapon()
    {
        if (_infAllAmmo)
        {
            int _amountAmmoLoad = _magazineSize - magazineAmmo;
            magazineAmmo += _amountAmmoLoad;
        }
        else
        {
            if (_allAmmo <= 0)
            {
                return;
            }
            else
            {
                int _amountAmmoLoad = _magazineSize - magazineAmmo;
                if (_allAmmo >= _amountAmmoLoad)
                {
                    magazineAmmo += _amountAmmoLoad;
                    _allAmmo -= _amountAmmoLoad;
                }
                else
                {
                    magazineAmmo += _allAmmo;
                    _allAmmo = 0;
                }
                
            }
            
        } 
    }

    void CheckMagazinAmmo()
    {
        if (magazineAmmo <= 0)
        {
            emptyAmmo = true;
        }
    }
}
