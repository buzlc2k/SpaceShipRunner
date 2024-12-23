using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChangingManager : Singleton<PhaseChangingManager>
{
    [Header("PhaseChangingManager")]
    [SerializeField] private PhaseChangingConfig phaseChangingConfig;
    private bool isCalculating = false;
    private float phaseChangingTimer;

    protected override void OnEnable()
    {
        base.OnEnable();
    
        InitializePhaseChanging();

        StartCoroutine(C_InitializeUpdatePhaseChanging());  
    }

    /// <summary>
    /// Tiến hành cập nhật phase của trò chơi
    /// </summary>
    public void InitializePhaseChanging()
    {
        isCalculating = true;
    }

    /// <summary>
    /// Tạm dừng cập nhật phase của trò chơi
    /// </summary>
    public void PausePhaseChanging()
    {
        isCalculating = false;
    }

    IEnumerator C_InitializeUpdatePhaseChanging(){
        SetUpPhaseChanging();

        while(true){
            yield return StartCoroutine(C_UpdatePhaseChanging());   
        }
    }

    private void SetUpPhaseChanging(){
        phaseChangingTimer = phaseChangingConfig.TimeInterval;

        var colorPicked = phaseChangingConfig.InitialListColor[UnityEngine.Random.Range(0, phaseChangingConfig.InitialListColor.Count)];

        var initialCurrentColor = colorPicked.InitialCurrentColor;
        var initialTargetColor = colorPicked.InitialTargetColor;

        Observer.PostEvent(EventID.InitializeUpdatePhaseChanging, 
            new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeUpdatePhaseChanging_TupleColor, Tuple.Create<Color, Color>(initialCurrentColor, initialTargetColor)));
    }

    IEnumerator C_UpdatePhaseChanging(){
        if(isCalculating){
            phaseChangingTimer -= Time.deltaTime * (1+ DifficultyManager.Instance.GameSpeedRate);
            if(phaseChangingTimer < 0){
                phaseChangingTimer = phaseChangingConfig.TimeInterval;
                Observer.PostEvent(EventID.ChangePhase, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangePhase_Null, null));
            }
            yield return null;
        }
    }
}
