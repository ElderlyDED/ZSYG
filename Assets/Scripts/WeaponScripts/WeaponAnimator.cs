using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimator : MonoBehaviour
{
    [SerializeField] Animation _gunAnim;
    [SerializeField] AnimationClip _shotAnim;
    [SerializeField] AnimationClip _downAnim;
    [SerializeField] AnimationClip _upAnim;
    public void GunShotAnimation()
    {
        _gunAnim.clip = _shotAnim;
        _gunAnim.Play();
    }

    public void GunDownAnimation()
    {
        _gunAnim.clip = _downAnim;
        _gunAnim.Play();
    }

    public void GunUpAnimation()
    {
        _gunAnim.clip = _upAnim;
        _gunAnim.Play();
    }
}
