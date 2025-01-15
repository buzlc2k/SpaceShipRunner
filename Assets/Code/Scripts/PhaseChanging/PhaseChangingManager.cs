using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChangingManager : Singleton<PhaseChangingManager>
{
    [Header("PhaseChangingManager")]
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
        return GameManager.Instance.CurrentGameState.Equals(GameState.MainMenu) 
            || GameManager.Instance.CurrentGameState.Equals(GameState.Running) 
            || GameManager.Instance.CurrentGameState.Equals(GameState.Restarting);
    }

    private void SetUpPhaseChanging(){
        var colorPicked = phaseChangingConfig.InitialListColor[UnityEngine.Random.Range(0, phaseChangingConfig.InitialListColor.Count)];

        var initialCurrentColor = colorPicked.InitialCurrentColor;
        var initialTargetColor = colorPicked.InitialTargetColor;

        Observer.PostEvent(EventID.InitializeUpdatePhaseChanging, 
            new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeUpdatePhaseChanging_TupleColor, Tuple.Create<Color, Color>(initialCurrentColor, initialTargetColor)));
    }

    private void UpdatePhaseChanging(){
        phaseChangingTimer -= Time.deltaTime * (1+ DifficultyManager.Instance.GameSpeedRate);

        if(phaseChangingTimer < 0){
            phaseChangingTimer = phaseChangingConfig.TimeInterval;
            Observer.PostEvent(EventID.ChangePhase, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangePhase_Null, null));
        }
    }
}
