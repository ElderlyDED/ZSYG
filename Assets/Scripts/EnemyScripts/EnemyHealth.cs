using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] DieEnemy _dieEnemyScript;
    [SerializeField] int HP;
    bool OnDie;
    public void TakeDamage(int _damageCount)
    {
        HP -= _damageCount;
        
    }
    void Update()
    {
        if (OnDie == false)
        {
            if (HP <= 0)
            {
                OnDie = true;
                _dieEnemyScript.OnDieEnemy();
            }
        }
        
    }

}
