using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasOutlineMaterialChanging : BaseMaterialColorChanging
{
    [SerializeField] protected Material oulineMaterial;

    protected override void SetMaterialsColor(Color currentColor, Color targetColor)
    {
        base.SetMaterialsColor(currentColor, targetColor);
        oulineMaterial.SetColor("_CurrentColor", currentColor);
        oulineMaterial.SetColor("_TargetColor", targetColor);
    }

    protected override void SetMaterialFadeCount(float fadeCount){
        base.SetMaterialFadeCount(fadeCount);

        oulineMaterial.SetFloat("_FadeCount", fadeCount);
    }
}