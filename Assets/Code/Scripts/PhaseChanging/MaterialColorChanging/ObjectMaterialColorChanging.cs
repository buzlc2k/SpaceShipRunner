using UnityEngine;

public class ObjectMaterialColorChanging : BaseColorChanging
{
    protected override void SetColor(Color currentColor, Color targetColor)
    {
        Shader.SetGlobalColor("_CurrentColor", currentColor);
        Shader.SetGlobalColor("_TargetColor", targetColor);
    }

    protected override void SetFadeColor(float fadeCount){
        Color fadeColorCurrent = Color.Lerp(PhaseChangingManager.Instance.TargetColor, PhaseChangingManager.Instance.CurrentColor, fadeCount);
        Color fadeColorTarget = Color.Lerp(PhaseChangingManager.Instance.CurrentColor, PhaseChangingManager.Instance.TargetColor, fadeCount);
        
        SetColor(fadeColorCurrent, fadeColorTarget);
    }
}