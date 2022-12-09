using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour
{
    [SerializeField] public ParticleSystem flash;
    public void PlayFlash()
    {
        flash.Play();
    }
}
