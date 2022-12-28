using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloseEnemy : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] CloseEnemyAttack _attackScript;
    [SerializeField] CloseEnemyAnimator _closeEnemyAnimatorScript;
    [SerializeField] float _distanceToPlayer;
    [SerializeField] float _attackDistance;
    [SerializeField] float _enemySpeed;
    [SerializeField] bool _die;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _attackScript = GetComponent<CloseEnemyAttack>();
        _closeEnemyAnimatorScript = GetComponent<CloseEnemyAnimator>();
        _navMeshAgent.enabled = true;
    }
    void Update()
    {
        _navMeshAgent.SetDestination(_player.transform.position);
        _distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        if (_die == false)
        {
            DistanseDo();
        }
        
    }

    void DistanseDo()
    {
        if (_distanceToPlayer <= _attackDistance)
        {
            _navMeshAgent.speed = 0f;
            _attackScript.Attack();
        }
        else
        {
            _navMeshAgent.speed = _enemySpeed;
            _closeEnemyAnimatorScript.RunAmimation();

        }
    }

    public void StopMove()
    {
        _die = true;
        _navMeshAgent.speed = 0f;
    }
}
