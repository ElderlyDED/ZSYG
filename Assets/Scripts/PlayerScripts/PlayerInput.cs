using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsFire { get; private set; }
    public bool IsPressedFire { get; private set; }
    public bool NotPressedFire { get; private set; }
    public bool RealoadGun { get; private set; }
    public bool SelectSlot0 { get; private set; }
    public bool SelectSlot1 { get; private set; }
    public bool SelectSlot2 { get; private set; }
    public bool SelectSlot3 { get; private set; }
    public bool SelectSlot4 { get; private set; }
    public bool SelectSlot5 { get; private set; }

    public event Action Fired = default;
    public event Action PressedFire = default;
    public event Action OffPressedFire = default;
    public event Action ReloadingGun = default;
    public event Action SelectedSlot0 = default;
    public event Action SelectedSlot1 = default;
    public event Action SelectedSlot2 = default;
    public event Action SelectedSlot3 = default;
    public event Action SelectedSlot4 = default;
    public event Action SelectedSlot5 = default;

    void Update()
    {
        IsFire = Input.GetKey(KeyCode.Mouse0);
        if (IsFire && Fired != null)
        {
            Fired();
        }

        IsPressedFire = Input.GetKey(KeyCode.Mouse0);
        if (IsPressedFire && PressedFire != null)
        {
            PressedFire();
        }

        NotPressedFire = Input.GetKeyUp(KeyCode.Mouse0);
        if (NotPressedFire && OffPressedFire != null)
        {
            OffPressedFire();
        }

        RealoadGun = Input.GetKeyUp(KeyCode.R);
        if (RealoadGun && ReloadingGun != null)
        {
            ReloadingGun();
        }

        SelectSlot0 = Input.GetKeyUp(KeyCode.Alpha1);
        if (SelectSlot0 && SelectedSlot0 != null)
        {
            SelectedSlot0();
        }
        
        SelectSlot1 = Input.GetKeyUp(KeyCode.Alpha2);
        if (SelectSlot1 && SelectedSlot1 != null)
        {
            SelectedSlot1();
        }
        
        SelectSlot2 = Input.GetKeyUp(KeyCode.Alpha3);
        if (SelectSlot2 && SelectedSlot2 != null)
        {
            SelectedSlot2();
        }
        
        SelectSlot3 = Input.GetKeyUp(KeyCode.Alpha4);
        if (SelectSlot3 && SelectedSlot3 != null)
        {
            SelectedSlot3();
        }
        
        SelectSlot4 = Input.GetKeyUp(KeyCode.Alpha5);
        if (SelectSlot4 && SelectedSlot4 != null)
        {
            SelectedSlot4();
        }
        
        SelectSlot5 = Input.GetKeyUp(KeyCode.Alpha6);
        if (SelectSlot5 && SelectedSlot5 != null)
        {
            SelectedSlot5();
        }
    }
}
