using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEnemyAnimator : MonoBehaviour
{
    [SerializeField] Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void RunAmimation()
    {
        _animator.SetBool("Run Forward", true);
        _animator.SetBool("Punch Attack", false);
    }

    public void AttackAnimation()
    {
        _animator.SetBool("Punch Attack", true);
        _animator.SetBool("Run Forward", false);
    }

    public void DieAnimation()
    {
        _animator.SetTrigger("Die");
        _animator.SetBool("Punch Attack", false);
        _animator.SetBool("Run Forward", false);
    }
}
