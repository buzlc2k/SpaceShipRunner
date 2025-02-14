using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TextColorChanging : BaseColorChanging
{
    [SerializeField] List<Material> textMaterials_White = new();
    [SerializeField] List<Material> textMaterials_Black = new();
    
    protected override void SetColor(Color currentColor, Color targetColor)
    {
        SetTextColor(textMaterials_Black, targetColor);
        SetTextColor(textMaterials_White, currentColor);
    }

    protected virtual void SetTextColor(List<Material> textMaterials, Color fadeColor)
    {
        foreach(var textMaterial in textMaterials){
            textMaterial.SetColor("_FaceColor", fadeColor);
            textMaterial.SetColor("_UnderlayColor", fadeColor);
        }
    }

    protected override void SetFadeColor(float fadeCount){
        Color fadeColorBlack = Color.Lerp(PhaseChangingManager.Instance.TargetColor, PhaseChangingManager.Instance.CurrentColor, fadeCount);
        Color fadeColorWhite = Color.Lerp(PhaseChangingManager.Instance.CurrentColor, PhaseChangingManager.Instance.TargetColor, fadeCount);

        SetColor(fadeColorWhite, fadeColorBlack);
    }
}