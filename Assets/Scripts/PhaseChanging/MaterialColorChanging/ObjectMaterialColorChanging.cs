using UnityEngine;

public class ObjectMaterialColorChanging : BaseColorChanging
{
    protected override void SetColor(Color currentColor, Color targetColor)
    {
        Shader.SetGlobalColor("_CurrentColor", currentColor);
        Shader.SetGlobalColor("_TargetColor", targetColor);
    }

    protected override void SetFadeColor(float fadeCount){
        Shader.SetGlobalFloat("_FadeCount", fadeCount);
    }
}