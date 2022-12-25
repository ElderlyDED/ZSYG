using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCrate : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer _crate;
    [SerializeField] SkinnedMeshRenderer _crateLid;
    [SerializeField] float _dissolveRate;
    [SerializeField] float _refreshRate;
    [SerializeField] float _delayDestroy;
    public void OnDestroyCrate()
    {
        
        transform.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(DissovleEffect());
        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(_delayDestroy);
        Destroy(gameObject);
    }

    IEnumerator DissovleEffect()
    {
        float _counter = 0;
        while (_crate.material.GetFloat("_DissolveAmount") < 1 && _crateLid.material.GetFloat("_DissolveAmount") < 1)
        {
            _counter += _dissolveRate;
            _crate.material.SetFloat("_DissolveAmount", _counter);
            _crateLid.material.SetFloat("_DissolveAmount", _counter);
            yield return new WaitForSeconds(_refreshRate);
        }
    }
}
