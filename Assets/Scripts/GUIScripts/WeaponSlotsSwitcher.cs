using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSlotsSwitcher : MonoBehaviour
{
    [SerializeField] Transform _slotBox;
    public void SwitchSlot(int _slotId)
    {
        gameObject.GetComponent<SpawnWeaponSlots>().SpawnSlots();
        foreach (Transform _slot in _slotBox.transform)
        {
            if (_slotId == _slot.GetComponent<WeaponSlotSetInf>().slotID)
            {
                _slot.GetComponent<WeaponSlotActivator>().ActivSlot();
            }
            else
            {
                _slot.GetComponent<WeaponSlotActivator>().DeactivSlot();
            }
        }
        gameObject.GetComponent<SlotsPanelAnimator>().OnOffSlotBox();
    }
}
