using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class TestScript : MonoBehaviour
{
    [SerializeField] private VisualEffect vfx;

    [SerializeField] private bool isPause;
    
    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (!isPause)
            {
                vfx.playRate = 0;
                isPause = true;
                return;
            }

            if (isPause)
            {
                vfx.playRate = 1;
                isPause = false;
                return;
            }
            
        }
    }
}
