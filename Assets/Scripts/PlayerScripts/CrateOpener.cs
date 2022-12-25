using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateOpener : MonoBehaviour
{
    Camera _fpsCam;
    [SerializeField] float _rayRange;

    void Start()
    {
        _fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();   
    }

    void OnEnable()
    {
        gameObject.GetComponent<PlayerInput>().Interact += OnInteractCrate;
    }

    void OnDisable()
    {
        gameObject.GetComponent<PlayerInput>().Interact -= OnInteractCrate;
    }

    void OnInteractCrate()
    {
        RaycastHit _hit;
        if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out _hit, _rayRange))
        {
            if (_hit.transform.tag == "AmmoCrate")
            {
                _hit.transform.GetComponent<CrateOpenScript>().GetAmmoPlayer();
            }
        }
    }
}
