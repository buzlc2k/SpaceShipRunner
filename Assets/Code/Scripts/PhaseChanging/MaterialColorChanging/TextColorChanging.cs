using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TextColorChanging : BaseColorChanging
{
    [SerializeField] List<Material> textMaterials = new();
    protected override void SetColor(Color currentColor, Color targetColor)
    {
        SetColor(targetColor);
    }

    protected virtual void SetColor(Color fadeColor)
    {
        foreach(var textMaterial in textMaterials){
            textMaterial.SetColor("_FaceColor", fadeColor);
        }
    }

    protected override void SetFadeColor(float fadeCount){
        Color fadeColor = Color.Lerp(targetColor, currentColor, fadeCount);
        SetColor(fadeColor);
    }
}