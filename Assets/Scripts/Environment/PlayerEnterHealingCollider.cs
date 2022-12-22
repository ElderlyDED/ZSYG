using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterHealingCollider : MonoBehaviour
{
    [SerializeField] HealingHPStation _healingScript;
    [SerializeField] HealingTimer _healingTimer;

    void OnTriggerEnter(Collider other)
    {
        if (_healingTimer.ReadyHealing == true)
        {
            if (other.tag == "Player")
            {
                PlayerHPShield _playerHPShieldScript = other.GetComponent<PlayerHPShield>();
                if (_playerHPShieldScript.PlayerHP < _playerHPShieldScript.MaxPlayerHP || _playerHPShieldScript.PlayerShield < _playerHPShieldScript.MaxPlayerShield)
                {
                    _healingScript.HealingHP(other.GetComponent<PlayerHPShield>());
                    other.GetComponent<EffectPlayer>().PlayHealingEffect();
                    _healingTimer.StartTimer();
                }
                else 
                {
                    return;
                }           
            }
        }
        else
        {
            return;
        }
        
    }
}
