using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPShield : MonoBehaviour
{
    [field: SerializeField] public int MaxPlayerHP { get; private set; }
    [field: SerializeField] public int PlayerHP { get; private set; }
    [field: SerializeField] public int MaxPlayerShield { get; private set; }
    [field: SerializeField] public int PlayerShield { get; private set; }
    [SerializeField] int _shieldPower;

    public void MinusPlayerHpShiled(int _damageCount)
    {
        if (PlayerShield > 0)
        {
            PlayerShield -= _damageCount / _shieldPower;
        }
        else if (PlayerShield <= 0)
        {
            PlayerHP -= _damageCount;
        }
    }

    public void PlayerHealing()
    {
        PlayerHP = MaxPlayerHP;
        PlayerShield = MaxPlayerShield;
    }
}
