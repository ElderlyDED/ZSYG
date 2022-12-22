using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGUI : MonoBehaviour
{
    [SerializeField] GameObject _weaponSlots;
    [SerializeField] GameObject _weaponAmmoGui;
    [SerializeField] GameObject _chargerBarGui;
    public void WeaponSlotsSwitch(int _slotId)
    {
        _weaponSlots.GetComponent<WeaponSlotsSwitcher>().SwitchSlot(_slotId);
    }

    public void WeaponAmmoGuiSwitch(WeaponAmmo _weaponAmmo, GetGUIWeaponSlotInf _getWeaponScriptInf)
    {
        _weaponAmmoGui.GetComponent<SetAmmoInf>().SetInfAmmoGUI(_weaponAmmo, _getWeaponScriptInf);
    }

    public void WeaponEnableChargerBar(bool _onChargerBar, ChargaredGunShot _chargerGunShotScript)
    {
        _chargerBarGui.GetComponent<ChargerBarSetInf>().setInfChargerBar(_onChargerBar, _chargerGunShotScript);
    }
}
