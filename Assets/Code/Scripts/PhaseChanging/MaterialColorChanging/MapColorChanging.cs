using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapColorChanging : BaseColorChanging {
    protected override void SetColor(Color currentColor, Color targetColor)
    {
        //Do Nothing
    }

    protected virtual void SetColor(Color fadeColor)
    {
        RenderSettings.fogColor = fadeColor;
        CameraController.Instance.MainCamera.backgroundColor = fadeColor;
    }

    protected override void SetFadeColor(float fadeCount){
        Color fadeColor = Color.Lerp(PhaseChangingManager.Instance.TargetColor, PhaseChangingManager.Instance.CurrentColor, fadeCount);

        SetColor(fadeColor);
    }
}