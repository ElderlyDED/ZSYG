using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInteractText : MonoBehaviour
{
    Camera _fpsCam;
    [SerializeField] GameObject _interactText;
    [SerializeField] float _rayRange;
    void Start()
    {
        _fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    
    void Update()
    {
        RaycastHit _hit;
        if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out _hit, _rayRange))
        {
            if (_hit.transform.tag == "AmmoCrate")
            {
                _interactText.SetActive(true);
            }
            else
            {
                _interactText.SetActive(false);
            }
        }
    }
}
