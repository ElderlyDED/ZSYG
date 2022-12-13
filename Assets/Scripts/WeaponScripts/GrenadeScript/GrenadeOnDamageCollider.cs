using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeOnDamageCollider : MonoBehaviour
{
    [SerializeField] SphereCollider _damageCollider;
    [SerializeField] int _grenadeDamage;


    public void OnDamageCollider()
    {
        StartCoroutine(ColliderTimer());
    }

    IEnumerator ColliderTimer()
    {
        _damageCollider.enabled = true;   
        yield return new WaitForSeconds(1f);
        _damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyHealt>() != null)
        {
            EnemyHealt _enemyHealt = other.GetComponent<EnemyHealt>();
            gameObject.GetComponent<DamageEnemy>().GetDamage(_enemyHealt, _grenadeDamage);
        }
    }
}
