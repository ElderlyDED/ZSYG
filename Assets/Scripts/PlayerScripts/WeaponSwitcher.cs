using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] Transform _weaponHolder;
    [SerializeField] PlayerInput _playerInputScript;
    [SerializeField] Transform _lastWeapon;
    [SerializeField] int _selectSlot = 0;
    [SerializeField] List<Transform> _equipmentWeapons = new();
    [SerializeField] WeaponGUI _weaponGUI;

    void OnEnable()
    {
        _playerInputScript = gameObject.GetComponent<PlayerInput>();
        _playerInputScript.SelectedSlot0 += OnSelectSlot;
        _playerInputScript.SelectedSlot1 += OnSelectSlot;
        _playerInputScript.SelectedSlot2 += OnSelectSlot;
        _playerInputScript.SelectedSlot3 += OnSelectSlot;
        _playerInputScript.SelectedSlot4 += OnSelectSlot;
        _playerInputScript.SelectedSlot5 += OnSelectSlot;
    }
    void OnDisable()
    {
        _playerInputScript.SelectedSlot0 -= OnSelectSlot;
        _playerInputScript.SelectedSlot1 -= OnSelectSlot;
        _playerInputScript.SelectedSlot2 -= OnSelectSlot;
        _playerInputScript.SelectedSlot3 -= OnSelectSlot;
        _playerInputScript.SelectedSlot4 -= OnSelectSlot;
        _playerInputScript.SelectedSlot5 -= OnSelectSlot;
    }

    private void Start()
    {
        _weaponGUI = GameObject.FindGameObjectWithTag("GameUI").GetComponent<WeaponGUI>();
        UpStartGun();
    }

    void OnSelectSlot()
    {
        CheckAcvtivWeapon();
        bool _slot0 = _playerInputScript.SelectSlot0;
        if (_slot0 == true)
        {
            _selectSlot = 0;
        }
        bool _slot1 = _playerInputScript.SelectSlot1;
        if (_slot1 == true)
        {
            _selectSlot = 1;
        }
        bool _slot2 = _playerInputScript.SelectSlot2;
        if (_slot2 == true)
        {
            _selectSlot = 2;
        }
        bool _slot3 = _playerInputScript.SelectSlot3;
        if (_slot3 == true)
        {
            _selectSlot = 3;
        }
        bool _slot4 = _playerInputScript.SelectSlot4;
        if (_slot4 == true)
        {
            _selectSlot = 4;
        }
        bool _slot5 = _playerInputScript.SelectSlot5;
        if (_slot5 == true)
        {
            _selectSlot = 5;
        }
        int i = 0;
        foreach (Transform _weapon in _equipmentWeapons)
        {
            if (i == _selectSlot)
            {
                
                if (_weapon != _lastWeapon)
                {
                    _weapon.GetComponent<WeaponAnimator>().GunUpAnimation();
                    _lastWeapon.gameObject.SetActive(false);
                    _weapon.gameObject.SetActive(true);
                    _lastWeapon = _weapon;
                    _weaponGUI.WeaponSlotsSwitch(_weapon.GetComponent<GetGUIWeaponSlotInf>().WeaponSlotId);
                    _weaponGUI.WeaponAmmoGuiSwitch(_weapon.GetComponent<WeaponAmmo>(), _weapon.GetComponent<GetGUIWeaponSlotInf>());
                    if (_weapon.GetComponent<GetGUIWeaponSlotInf>().ChargerGunBar == true)
                    {
                        _weaponGUI.WeaponEnableChargerBar(_weapon.GetComponent<GetGUIWeaponSlotInf>().ChargerGunBar, _weapon.GetComponent<ChargaredGunShot>());
                    }
                    else
                    {
                        _weaponGUI.WeaponEnableChargerBar(_weapon.GetComponent<GetGUIWeaponSlotInf>().ChargerGunBar, null);
                    }

                }
                else if (_weapon == _lastWeapon)
                {
                    _weapon.gameObject.SetActive(false);
                    _lastWeapon.gameObject.SetActive(true);
                    _weaponGUI.WeaponSlotsSwitch(_weapon.GetComponent<GetGUIWeaponSlotInf>().WeaponSlotId);
                    _weaponGUI.WeaponAmmoGuiSwitch(_weapon.GetComponent<WeaponAmmo>(), _weapon.GetComponent<GetGUIWeaponSlotInf>());
                    if (_weapon.GetComponent<GetGUIWeaponSlotInf>().ChargerGunBar == true)
                    {
                        _weaponGUI.WeaponEnableChargerBar(_weapon.GetComponent<GetGUIWeaponSlotInf>().ChargerGunBar, _weapon.GetComponent<ChargaredGunShot>());
                    }
                    else
                    {
                        _weaponGUI.WeaponEnableChargerBar(_weapon.GetComponent<GetGUIWeaponSlotInf>().ChargerGunBar, null);
                    }

                }
                
            }
            else
            {
                if (_weapon != _lastWeapon && _selectSlot - 1 <= _equipmentWeapons.Count)
                {
                    _lastWeapon.gameObject.SetActive(true);

                }
                else if(_weapon != _lastWeapon && _selectSlot - 1 > _equipmentWeapons.Count)
                {
                    _weapon.gameObject.SetActive(false);
                }
            }
            i++;
            
        }
    }

    void UpStartGun()
    {
        Transform _firstGunUp = _weaponHolder.GetChild(0).transform;
        _firstGunUp.gameObject.SetActive(true);
        _lastWeapon = _firstGunUp;
        _firstGunUp.GetComponent<WeaponAnimator>().GunUpAnimation();
    }
    [ContextMenu("UpdateList")]
    void CheckAcvtivWeapon()
    {
        _equipmentWeapons.Clear();
        foreach (Transform _weaponObj in _weaponHolder.transform)
        {
            if (_weaponObj.GetComponent<WeaponEquip>().weaponEquip == true)
            {
                _equipmentWeapons.Add(_weaponObj);
            }
        }
    } 
}
