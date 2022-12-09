using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool IsFire { get; private set; }

    public event Action Fired = default;
    void Update()
    {
        IsFire = Input.GetKey(KeyCode.Mouse0);

        if (IsFire && Fired != null)
        {
            Fired();
        }
    }
}
