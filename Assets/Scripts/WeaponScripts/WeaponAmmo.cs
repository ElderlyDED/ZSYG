using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    [SerializeField] int _magazineSize;
    [field: SerializeField] public int MagazineAmmo { get; private set; }
    [field: SerializeField] public bool EmptyAmmo { get; private set; }
    [field: SerializeField] public int AllAmmo { get; private set; }
    [SerializeField] int _maxAllAmmo;
    [field: SerializeField] public bool NotMagazine { get; private set; }
    [field: SerializeField] public bool InfAllAmmo { get; private set; }

    void Update()
    {
        CheckMagazinAmmo();
    }

    public void ShotMinusAmmo()
    {
        if (NotMagazine == true)
        {
            AllAmmo--;
        }
        else
        {
            MagazineAmmo--;
        } 
   
    }

    public void ReloadWeapon()
    {
        if (InfAllAmmo)
        {
            int _amountAmmoLoad = _magazineSize - MagazineAmmo;
            MagazineAmmo += _amountAmmoLoad;
        }
        else
        {
            if (AllAmmo <= 0)
            {
                return;
            }
            else
            {
                int _amountAmmoLoad = _magazineSize - MagazineAmmo;
                if (AllAmmo >= _amountAmmoLoad)
                {
                    MagazineAmmo += _amountAmmoLoad;
                    AllAmmo -= _amountAmmoLoad;
                }
                else
                {
                    MagazineAmmo += AllAmmo;
                    AllAmmo = 0;
                }
                
            }
            
        } 
    }

    void CheckMagazinAmmo()
    {
        if (NotMagazine == false && AllAmmo <= 0 && MagazineAmmo <= 0)
        {
            EmptyAmmo = true;
        }

        if (NotMagazine == true && AllAmmo <= 0)
        {
            EmptyAmmo = true;
        }
    }

    public void FillAmmo()
    {
        MagazineAmmo = _magazineSize;
        AllAmmo = _maxAllAmmo;
    }
}
