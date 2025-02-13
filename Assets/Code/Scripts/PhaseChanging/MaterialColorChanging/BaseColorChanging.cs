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

    protected override void SetUpDelegate(){
        setColor ??= param => {
            
            Tuple<Color, Color> colorData = (Tuple<Color, Color>)param.Value;

            InitilizeSetColor(colorData.Item1, colorData.Item2);
        };

        initializeChangingColor ??= (param) => {
            InitializeChangingColor();
        };
    }

    protected override void RegisterListener()
    {
        base.RegisterListener();

        Observer.AddListener(EventID.InitializeUpdatePhaseChanging, setColor);
        Observer.AddListener(EventID.ChangePhase, initializeChangingColor);
    }

    protected override void UnregisterListener()
    {
        base.UnregisterListener();

        Observer.RemoveListener(EventID.InitializeUpdatePhaseChanging, setColor);
        Observer.RemoveListener(EventID.ChangePhase, initializeChangingColor);
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
        (currentColor, targetColor) = (targetColor, currentColor);

        SetColor(currentColor, targetColor);

        yield return StartCoroutine(C_FadeColor());
    }

    protected virtual IEnumerator C_FadeColor(){
        float fadeCount = 1;

        while(fadeCount > 0){
            fadeCount -= Time.deltaTime * (1 + DifficultyManager.Instance.GameSpeedRate);
            if(fadeCount < 0) fadeCount = 0;
            SetFadeColor(fadeCount);
            yield return null;
        }
    }

    protected abstract void SetFadeColor(float fadeCount);
}