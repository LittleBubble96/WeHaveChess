using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_UI;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class C_Camera : Bubble_MonoSingle<C_Camera>
{
    [HideInInspector]
    public Camera mainCamera;
    
    public void Init()
    {
        mainCamera = GetComponent<Camera>();

    }
}
