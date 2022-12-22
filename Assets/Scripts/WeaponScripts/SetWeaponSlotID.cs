using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWeaponSlotID : MonoBehaviour
{
    void Start()
    {
        int idNumber = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            idNumber++;
            transform.GetChild(i).GetComponent<GetGUIWeaponSlotInf>().SetWeaponSlotId(idNumber);
        }
    }
}
