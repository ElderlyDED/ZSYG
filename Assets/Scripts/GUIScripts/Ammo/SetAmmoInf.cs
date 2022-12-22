using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetAmmoInf : MonoBehaviour
{
    [SerializeField] Image _ammoIcon;
    [SerializeField] TextMeshProUGUI _ammoText;
    [SerializeField] WeaponAmmo _weaponAmmoScript;
    [SerializeField] bool _notMagazine;
    [SerializeField] bool _infAmmo;
    void Update()
    {
        if (_weaponAmmoScript != null)
        {
            if (_notMagazine == false && _infAmmo == false)
            {
                _ammoText.text = _weaponAmmoScript.MagazineAmmo.ToString() + " / " + _weaponAmmoScript.AllAmmo.ToString();
            }
            else if (_notMagazine == true && _infAmmo == false)
            {
                _ammoText.text = _weaponAmmoScript.AllAmmo.ToString();
            }
            else if (_notMagazine == false && _infAmmo == true)
            {
                _ammoText.text = _weaponAmmoScript.MagazineAmmo.ToString() + " / \u221e";
            }
        }
        else
        {
            return;
        }
        
    }

    public void SetInfAmmoGUI(WeaponAmmo _weaponAmmo, GetGUIWeaponSlotInf _getWeaponScriptInf)
    {
        _weaponAmmoScript = _weaponAmmo;
        _notMagazine = _weaponAmmo.NotMagazine;
        _infAmmo = _weaponAmmo.InfAllAmmo;
        _ammoIcon.sprite = _getWeaponScriptInf.AmmoIcon;
    }
}
