using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChangingManager : Singleton<PhaseChangingManager>
{
    [Header("PhaseChangingManager")]
    [HideInInspector] public Color CurrentColor;
    [HideInInspector] public Color TargetColor;
    [SerializeField] private PhaseChangingConfig phaseChangingConfig;
    private float phaseChangingTimer;

    protected override void LoadValue()
    {
        base.LoadValue();

        phaseChangingTimer = phaseChangingConfig.TimeInterval;
    }

    protected override void Start()
    {
        base.Start();

        SetUpPhaseChanging();
    }

    private void Update(){
        if(!CheckCanUpdatePhaseChanging()) return;

        UpdatePhaseChanging();
    }

    protected virtual bool CheckCanUpdatePhaseChanging(){
        return !GameManager.Instance.CurrentGameState.Equals(GameState.StartTransition) 
            && !GameManager.Instance.CurrentGameState.Equals(GameState.EndTransition);
    }

    private void SetUpPhaseChanging(){
        var colorPicked = phaseChangingConfig.InitialListColor[UnityEngine.Random.Range(0, phaseChangingConfig.InitialListColor.Count)];

        CurrentColor = colorPicked.InitialCurrentColor;
        TargetColor = colorPicked.InitialTargetColor;

        Observer.PostEvent(EventID.InitializeUpdatePhaseChanging, 
            new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeUpdatePhaseChanging_Null, null));
    }

    private void UpdatePhaseChanging(){
        phaseChangingTimer -= Time.deltaTime * (1+ DifficultyManager.Instance.GameSpeedRate);

        if(phaseChangingTimer < 0){
            phaseChangingTimer = phaseChangingConfig.TimeInterval;

            (CurrentColor, TargetColor) = (TargetColor, CurrentColor);

            Observer.PostEvent(EventID.ChangePhase, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangePhase_Null, null));
        }
    }
}
