using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateOpenScript : MonoBehaviour
{
    public void GetAmmoPlayer() 
    {
        Transform _weaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder").GetComponent<Transform>();
        foreach (Transform _weapon in _weaponHolder)
        {
            if (_weapon.GetComponent<WeaponEquip>().weaponEquip == true)
            {
                _weapon.GetComponent<WeaponAmmo>().FillAmmo();
            }
            else
            {
                break;
            }
        }
        gameObject.GetComponent<DestroyCrate>().OnDestroyCrate();
    }
}
