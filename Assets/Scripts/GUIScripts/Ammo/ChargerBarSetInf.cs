using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargerBarSetInf : MonoBehaviour
{
    [SerializeField] GameObject _sliderBox;
    [SerializeField] Slider _chargerBarSlider;
    [SerializeField] bool _onSlider;
    [SerializeField] ChargaredGunShot _chargerGunShot;

    void Update()
    {
        if (_onSlider == true && _chargerGunShot != null)
        {
            _sliderBox.SetActive(true);
            _chargerBarSlider.maxValue = _chargerGunShot.maxCharge;
            _chargerBarSlider.value = _chargerGunShot.chargaredTime;
        }
        else if (_onSlider == false && _chargerGunShot == null)
        {
            _sliderBox.SetActive(false);
            return;
        }
    }

    public void setInfChargerBar(bool _onChargerBar, ChargaredGunShot _chargerGunShotScript)
    {
        _onSlider = _onChargerBar;
        _chargerGunShot = _chargerGunShotScript;
    }
}
