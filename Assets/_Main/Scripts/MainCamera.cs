using System;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [Obsolete("Obsolete")]
    private void Awake()
    {
        UnityEngine.Application.targetFrameRate = 90;
        if (OVRManager.display != null)
        {
            OVRManager.display.displayFrequency = 90.0f;
        }
        OVRManager.fixedFoveatedRenderingLevel = OVRManager.FixedFoveatedRenderingLevel.High;
        OVRManager.useDynamicFixedFoveatedRendering = true;
    }
}