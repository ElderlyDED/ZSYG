using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsPanelAnimator : MonoBehaviour
{
    [SerializeField] Animation _slotsBoxAnimation;
    [SerializeField] AnimationClip _hideSlotBox;
    [SerializeField] AnimationClip _showSlotBox;
    [SerializeField] float _timeShowingSlotBox;
    [SerializeField] bool _showing;
    void Awake()
    {
        _slotsBoxAnimation.clip = _hideSlotBox;
        _slotsBoxAnimation.Play();
    }

    public void OnOffSlotBox()
    {
        if (_showing == false)
        {
            //StopCoroutine(OnOffSlotBoxAnimation());
            StartCoroutine(OnOffSlotBoxAnimation());
        }
        else
        {
            return;
        }
        
    }

    IEnumerator OnOffSlotBoxAnimation()
    {   
        _showing = true;
        _slotsBoxAnimation.clip = _showSlotBox;
        _slotsBoxAnimation.Play();
        yield return new WaitForSeconds(_timeShowingSlotBox);
        _slotsBoxAnimation.clip = _hideSlotBox;
        _slotsBoxAnimation.Play();
        _showing = false;
    }


}
