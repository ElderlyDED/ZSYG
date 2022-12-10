using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsFire { get; private set; }
    public bool IsPressedFire { get; private set; }
    public bool NotPressedFire { get; private set; }

    public event Action Fired = default;
    public event Action PressedFire = default;
    public event Action OffPressedFire = default;
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


    }
}
