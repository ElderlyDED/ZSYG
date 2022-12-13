using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public void GetDamage(EnemyHealt eh, int _damage)
    {
        if (eh != null)
        {
            eh.TakeDamage(_damage);
        }
    }
}
