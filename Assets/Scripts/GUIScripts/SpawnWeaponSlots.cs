using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeaponSlots : MonoBehaviour
{
    [SerializeField] GameObject _slotPrefab;
    [SerializeField] Transform _slotBox;
    [ContextMenu("SoawnSlots")]
    public void SpawnSlots()
    {
        DeletSlots();
        GameObject _weaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder");
        foreach (Transform child in _weaponHolder.transform)
        {
            if (child.GetComponent<WeaponEquip>().weaponEquip == true)
            {
                GameObject _slotObj = Instantiate(_slotPrefab, transform);
                _slotObj.GetComponent<WeaponSlotSetInf>().SetSlotInf(child.GetComponent<GetGUIWeaponSlotInf>().WeaponIcon, 
                child.GetComponent<GetGUIWeaponSlotInf>().WeaponSlotId);
                _slotObj.transform.SetParent(_slotBox);
                
            }
        }
    }
    void DeletSlots()
    {
        foreach (Transform child in _slotBox.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
