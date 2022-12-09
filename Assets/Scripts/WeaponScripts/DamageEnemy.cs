using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] int _damage;
    public void GetDamage(EnemyHealt eh)
    {
        if (eh != null)
        {
            eh.TakeDamage(_damage);
        }
    }
}
