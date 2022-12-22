using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotActivator : MonoBehaviour
{
    [SerializeField] GameObject _activPanel;
    public void ActivSlot()
    {
        _activPanel.SetActive(true);
    }

    public void DeactivSlot()
    {
        _activPanel.SetActive(false);
    }
}
