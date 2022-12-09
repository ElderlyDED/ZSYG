using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeRotationScript : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;
    private void Update()
    {
        transform.Rotate(_rotationSpeed, _rotationSpeed, _rotationSpeed);
    }

}
