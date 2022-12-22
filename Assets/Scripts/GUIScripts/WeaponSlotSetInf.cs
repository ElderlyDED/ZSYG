using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotSetInf : MonoBehaviour
{
    [SerializeField] Image _gunIconObj;
    [SerializeField] public int slotID;

    public void SetSlotInf(Sprite _gunIcon, int _sid)
    {
        slotID = _sid;
        _gunIconObj.sprite = _gunIcon;
    }
}
