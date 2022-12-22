using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] ParticleSystem _healingEffect;

    public void PlayHealingEffect()
    {
        _healingEffect.Play();
    }
}
