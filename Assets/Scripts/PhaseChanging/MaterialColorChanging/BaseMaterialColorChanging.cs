using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMaterialColorChanging : ButMonobehavior
{
    [Header("BaseMaterialColorChanging")]
    protected Color currentColor;
    protected Color targetColor;
    [SerializeField] protected float colorIntensity = 2.1f;
    [SerializeField] protected Material objMaterial;
    [SerializeField] protected ObjectType objectType;

    private Action<KeyValuePair<EventParameterType, object>> setColor; 
    private Action<KeyValuePair<EventParameterType, object>> initializeChangingColor; 

    protected override void OnEnable(){
        base.OnEnable();

        SetUpDelegate();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.InitializeUpdatePhaseChanging, setColor);
        Observer.RemoveListener(EventID.ChangePhase, initializeChangingColor);
    }

    protected virtual void SetUpDelegate(){
        setColor ??= param => {
            if (param.Key != EventParameterType.InitializeUpdatePhaseChanging_TupleColor) return;

            Tuple<Color, Color> colorData = (Tuple<Color, Color>)param.Value;

            InitilizeSetColor(colorData.Item1, colorData.Item2);
        };

        initializeChangingColor ??= (param) => {
            InitializeChangingColor();
        };

        Observer.AddListener(EventID.InitializeUpdatePhaseChanging, setColor);
        Observer.AddListener(EventID.ChangePhase, initializeChangingColor);
    }

    protected virtual void InitilizeSetColor(Color currentColor, Color targetColor){
        Tuple<Color, Color> colorData = ApplyColorIntensity(currentColor, targetColor);

        SetThisColor(colorData.Item1, colorData.Item2);

        SetMaterialFadeCount(0);
        SetMaterialsColor(this.currentColor, this.targetColor);
    }

    private Tuple<Color, Color> ApplyColorIntensity(Color currentColor, Color targetColor){
        float factor = Mathf.Pow(2, colorIntensity);
        currentColor = new Color(currentColor.r * factor, currentColor.g *factor, currentColor.b * factor);
        targetColor = new Color(targetColor.r * factor, targetColor.g * factor, targetColor.b * factor);

        return Tuple.Create(currentColor, targetColor);
    }

    protected virtual void SetThisColor(Color currentColor, Color targetColor){
        if(objectType.Equals(ObjectType.Black))
            (currentColor, targetColor) = (targetColor, currentColor);
        
        this.currentColor = currentColor;
        this.targetColor = targetColor;
    }

    protected virtual void SetMaterialsColor(Color currentColor, Color targetColor){
        objMaterial.SetColor("_CurrentColor", currentColor);
        objMaterial.SetColor("_TargetColor", targetColor);
    }

    protected virtual void InitializeChangingColor(){
        StartCoroutine(C_ChangingColor());
    }

    protected virtual IEnumerator C_ChangingColor(){
        (this.currentColor, this.targetColor) = (this.targetColor, this.currentColor);

        SetMaterialsColor(this.currentColor, this.targetColor);

        yield return StartCoroutine(C_FadeColor());
    }

    protected virtual IEnumerator C_FadeColor(){
        float fadeCount = 1;

        while(fadeCount >= 0){
            fadeCount -= Time.deltaTime * (1 + DifficultyManager.Instance.GameSpeedRate);
            SetMaterialFadeCount(fadeCount);
            yield return null;
        }
    }

    protected virtual void SetMaterialFadeCount(float fadeCount){
        objMaterial.SetFloat("_FadeCount", fadeCount);
    }
}