using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChangingManager : Singleton<PhaseChangingManager>
{
    [Header("PhaseChangingManager")]
    [SerializeField] private PhaseChangingConfig phaseChangingConfig;
    private bool canCalculate;
    private float phaseChangingTimer;

    private Action<KeyValuePair<EventParameterType, object>> initializeUpdatePhaseChanging;

    protected override void Start()
    {
        base.Start();
        
        StartCoroutine(C_InitializeUpdatePhaseChanging());
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    
        SetUpDelegate(); 
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.InitializeUpdateGame, initializeUpdatePhaseChanging);
    }

    protected override void LoadValue()
    {
        base.LoadValue();

        canCalculate = false;        
        phaseChangingTimer = phaseChangingConfig.TimeInterval;
    }

    //Tạo các delegate để lắng nghe sự kiện
    protected virtual void SetUpDelegate(){
        initializeUpdatePhaseChanging ??= (param) => {
            InitializeUpdatePhaseChanging();
        };

        Observer.AddListener(EventID.InitializeUpdateGame, initializeUpdatePhaseChanging);
    }

    /// <summary>
    /// Tiến hành cập nhật phase của trò chơi
    /// </summary>
    public void InitializeUpdatePhaseChanging()
    {
        canCalculate = true;
    }

    /// <summary>
    /// Tạm dừng cập nhật phase của trò chơi
    /// </summary>
    public void PauseUpdatePhaseChanging()
    {
        canCalculate = false;
    }

    IEnumerator C_InitializeUpdatePhaseChanging(){
        SetUpPhaseChanging();

        while(true){
            yield return StartCoroutine(C_UpdatePhaseChanging());   
        }
    }

    private void SetUpPhaseChanging(){
        var colorPicked = phaseChangingConfig.InitialListColor[UnityEngine.Random.Range(0, phaseChangingConfig.InitialListColor.Count)];

        var initialCurrentColor = colorPicked.InitialCurrentColor;
        var initialTargetColor = colorPicked.InitialTargetColor;

        Observer.PostEvent(EventID.InitializeUpdatePhaseChanging, 
            new KeyValuePair<EventParameterType, object>(EventParameterType.InitializeUpdatePhaseChanging_TupleColor, Tuple.Create<Color, Color>(initialCurrentColor, initialTargetColor)));
    }

    IEnumerator C_UpdatePhaseChanging(){
        if(canCalculate){
            phaseChangingTimer -= Time.deltaTime * (1+ DifficultyManager.Instance.GameSpeedRate);
            if(phaseChangingTimer < 0){
                phaseChangingTimer = phaseChangingConfig.TimeInterval;
                Observer.PostEvent(EventID.ChangePhase, new KeyValuePair<EventParameterType, object>(EventParameterType.ChangePhase_Null, null));
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        else
            yield return new WaitForSeconds(Time.deltaTime);
    }
}
