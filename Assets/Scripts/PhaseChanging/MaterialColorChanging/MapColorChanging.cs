using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapColorChanging : ButMonobehavior {

    [Header("MapColorChanging")]
    [SerializeField] protected Color currentColor;
    [SerializeField] protected Color targetColor;
    private Action<KeyValuePair<EventParameterType, object>> setMapColor; 
    private Action<KeyValuePair<EventParameterType, object>> initializeChangingColor;

    protected override void OnEnable()
    {
        base.OnEnable();

        SetUpDelegate();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.InitializeUpdatePhaseChanging, setMapColor);
        Observer.RemoveListener(EventID.ChangePhase, initializeChangingColor);
    }

    protected virtual void SetUpDelegate(){
        setMapColor ??= param => {
            if (param.Key != EventParameterType.InitializeUpdatePhaseChanging_TupleColor) return;

            Tuple<Color, Color> colorData = (Tuple<Color, Color>)param.Value;

            InitializeSetColor(colorData.Item1, colorData.Item2);
        };

        initializeChangingColor ??= (param) => {
            InitializeChangingColor();
        };

        Observer.AddListener(EventID.InitializeUpdatePhaseChanging, setMapColor);
        Observer.AddListener(EventID.ChangePhase, initializeChangingColor);
    }

    private void InitializeSetColor(Color currentColor, Color targetColor){
        SetColor(currentColor, targetColor);
        SetMapColor(this.currentColor);
    }

    private void SetColor(Color currentColor, Color targetColor){
        this.currentColor = currentColor;
        this.targetColor = targetColor;
    }

    private void SetMapColor(Color currentColor){
        RenderSettings.fogColor = currentColor;
        CameraController.Instance.MainCamera.backgroundColor = currentColor;
    }

    protected virtual void InitializeChangingColor(){
        StartCoroutine(C_ChangingColor());
    }

    protected virtual IEnumerator C_ChangingColor(){
        yield return StartCoroutine(C_FadeColor());

        (currentColor, targetColor) = (targetColor, currentColor);
    }

    protected virtual IEnumerator C_FadeColor(){
        float fadeCount = 0;

        while(fadeCount <= 1){
            fadeCount += Time.deltaTime * (1 + DifficultyManager.Instance.GameSpeedRate);
            
            Color fadeColor = Color.Lerp(currentColor, targetColor, fadeCount);

            SetMapColor(fadeColor);

            yield return null;
        }
    }

}