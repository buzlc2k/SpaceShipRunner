using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseColorChanging : ButMonobehavior
{
    [Header("BaseColorChanging")]
    protected Color currentColor;
    protected Color targetColor;

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
        SetThisColor(currentColor, targetColor);

        SetFadeColor(0);
        SetColor(this.currentColor, this.targetColor);
    }

    protected virtual void SetThisColor(Color currentColor, Color targetColor){        
        this.currentColor = currentColor;
        this.targetColor = targetColor;
    }

    protected abstract void SetColor(Color currentColor, Color targetColor);

    protected virtual void InitializeChangingColor(){
        StartCoroutine(C_ChangingColor());
    }

    protected virtual IEnumerator C_ChangingColor(){
        (this.currentColor, this.targetColor) = (this.targetColor, this.currentColor);

        SetColor(this.currentColor, this.targetColor);

        yield return StartCoroutine(C_FadeColor());
    }

    protected virtual IEnumerator C_FadeColor(){
        float fadeCount = 1;

        while(fadeCount >= 0){
            fadeCount -= Time.deltaTime * (1 + DifficultyManager.Instance.GameSpeedRate);
            SetFadeColor(fadeCount);
            yield return null;
        }
    }

    protected abstract void SetFadeColor(float fadeCount);
}