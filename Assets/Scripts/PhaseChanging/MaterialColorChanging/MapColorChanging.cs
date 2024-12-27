using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapColorChanging : BaseColorChanging {
    protected override void SetColor(Color currentColor, Color targetColor)
    {
        RenderSettings.fogColor = currentColor;
        CameraController.Instance.MainCamera.backgroundColor = currentColor;
    }

    protected virtual void SetColor(Color currentColor)
    {
        RenderSettings.fogColor = currentColor;
        CameraController.Instance.MainCamera.backgroundColor = currentColor;
    }

    protected override void SetFadeColor(float fadeCount){
        Color fadeColor = Color.Lerp(currentColor, targetColor, fadeCount);

        SetColor(fadeColor);
    }

}