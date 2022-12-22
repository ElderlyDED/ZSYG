using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGUIWeaponSlotInf : MonoBehaviour
{
    [field: SerializeField] public Sprite WeaponIcon { get; private set; }

    [field: SerializeField] public int WeaponSlotId { get; private set; }
    [field: SerializeField] public Sprite AmmoIcon { get; private set; }
    [field: SerializeField] public bool ChargerGunBar { get; private set; }

    public void SetWeaponSlotId(int id)
    {
        WeaponSlotId = id;
    }
}
