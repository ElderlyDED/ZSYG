using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARWeaponShot : MonoBehaviour
{
    Camera _fpsCam;
    [SerializeField] int _damage;
    [SerializeField] float _range;
    [SerializeField] float _fireRate;
    float _nextTimeToFire = 0f;
    [SerializeField] FlashScript _flashScript;
    [SerializeField] ShotImpactScript _shotImpactScript;
    void Start()
    {
        _fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _flashScript = gameObject.GetComponent<FlashScript>();
        _shotImpactScript = gameObject.GetComponent<ShotImpactScript>();
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().Fired += OnFired;
    }

    private void OnDisable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().Fired -= OnFired;
    }

    private void OnFired()
    {
        if (Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            RaycastHit hit;
            _flashScript.PlayFlash();
            if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out hit, _range))
            {
                Debug.Log(hit.transform.name);
                _shotImpactScript.SpawnImpact(hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        
        
    }
}
