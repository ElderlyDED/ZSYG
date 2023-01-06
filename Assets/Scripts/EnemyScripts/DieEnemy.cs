using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour
{
    [SerializeField] CloseEnemyAnimator _animator;
    [SerializeField] CloseEnemy _enemyScript;
    [SerializeField] float _delayDie;
    [SerializeField] float _dissolveRateDis;
    [SerializeField] float _refreshRateDis;
    [SerializeField] SkinnedMeshRenderer _skinRenderer;
    [SerializeField] BoxCollider _enemyCollider;
    public void OnDieEnemy()
    {
        _enemyCollider.enabled = false;
        _enemyScript.StopMove();
        StartCoroutine(DieDelay());
        _animator.DieAnimation();
        StartCoroutine(DissovleEffect());
    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(_delayDie);
        Destroy(gameObject);
    }

    IEnumerator DissovleEffect()
    {
        float _counter = 0;
        while (_skinRenderer.material.GetFloat("_DissolveAmount") < 1)
        {
            _counter += _dissolveRateDis;
            _skinRenderer.material.SetFloat("_DissolveAmount", _counter);
            yield return new WaitForSeconds(_refreshRateDis);
        }
    }
}
