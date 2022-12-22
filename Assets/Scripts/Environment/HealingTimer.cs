using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTimer : MonoBehaviour
{
    [field: SerializeField] public bool ReadyHealing { get; private set; }
    [SerializeField] int _delayHealingReady;
    [SerializeField] GameObject _healingCylinder;


    public void StartTimer()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        _healingCylinder.SetActive(false);
        ReadyHealing = false;
        yield return new WaitForSeconds((float)_delayHealingReady);
        ReadyHealing = true;
        _healingCylinder.SetActive(true);
    }

}
