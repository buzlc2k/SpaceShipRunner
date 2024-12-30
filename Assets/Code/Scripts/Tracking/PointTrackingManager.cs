using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrackingManager : Singleton<PointTrackingManager>
{
    private float currentPoint;
    private bool canCalculate;

    private Action<KeyValuePair<EventParameterType, object>> initializeUpdatePoint;

    #region Property

    public float CurrentPoint { get => currentPoint; }

    #endregion

    protected override void Start()
    {
        base.Start();

        StartCoroutine(C_InitializeUpdatePoint());
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    
        SetUpDelegate(); 
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.InitializeUpdateGame, initializeUpdatePoint);
    }

    protected override void LoadValue()
    {
        base.LoadValue();

        currentPoint = 0;
        canCalculate = false;
    }

    //Tạo các delegate để lắng nghe sự kiện
    protected virtual void SetUpDelegate(){
        initializeUpdatePoint ??= (param) => {
            InitializeUpdatePoint();
        };

        Observer.AddListener(EventID.InitializeUpdateGame, initializeUpdatePoint);
    }

    /// <summary>
    /// Tiến hành cập nhật điểm của người chơi
    /// </summary>
    public void InitializeUpdatePoint()
    {
        canCalculate = true;
    }

    /// <summary>
    /// Tạm dừng cập nhật điểm của người chơi
    /// </summary>
    public void PauseUpdatePoint()
    {
        canCalculate = false;
    }

    private IEnumerator C_InitializeUpdatePoint(){
        while(true){
            yield return StartCoroutine(C_UpdatePoint());;
        }
    }

    IEnumerator C_UpdatePoint(){
        if(canCalculate){
            currentPoint += 5 * Time.deltaTime * (1 + DifficultyManager.Instance.GameSpeedRate);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        else
            yield return new WaitForSeconds(Time.deltaTime);
    }
}