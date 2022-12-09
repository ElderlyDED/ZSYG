using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    [SerializeField] int HP;

    public void TakeDamage(int _damageCount)
    {
        HP -= _damageCount;
    }
}
