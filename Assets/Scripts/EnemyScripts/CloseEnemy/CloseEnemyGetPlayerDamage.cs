using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemyGetPlayerDamage : MonoBehaviour
{
    [SerializeField] CloseEnemyAttack _closeEnemyAttackScript; 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHPShield>().MinusPlayerHpShiled(_closeEnemyAttackScript._attackDamage);
        }
    }
}
