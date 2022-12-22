using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingHPStation : MonoBehaviour
{
    public void HealingHP(PlayerHPShield _playerHpScript)
    {
        _playerHpScript.PlayerHealing();
    }
}
