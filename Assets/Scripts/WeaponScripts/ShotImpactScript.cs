using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotImpactScript : MonoBehaviour
{
    [SerializeField] ParticleSystem _impactEffect;

    public void SpawnImpact(Vector3 point, Quaternion normal)
    {
        Instantiate(_impactEffect, point, normal);
    }
}
