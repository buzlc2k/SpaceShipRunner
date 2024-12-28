using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDifficulty : ButMonobehavior
{
    [Header("BaseDifficulty")]
    protected float currentTime;
    protected static float maxTimeToCalculate;
    protected bool canCalculate;

    private Action<KeyValuePair<EventParameterType, object>> initializeUpdateDifficultyDelegate; 
    private Action<KeyValuePair<EventParameterType, object>> initiallizeResetUpdateDifficulty;

    protected override void OnEnable(){
        base.OnEnable();

        SetUpDelegate();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Observer.RemoveListener(EventID.InitializeUpdateGame, initializeUpdateDifficultyDelegate);
        Observer.RemoveListener(EventID.InitializeResetUpdateGame, initiallizeResetUpdateDifficulty);
    }

    protected override void LoadValue() {
        base.LoadValue();

        currentTime = 0f;
        canCalculate = false;
    }

    //Tạo các delegate để lắng nghe sự kiện
    protected virtual void SetUpDelegate(){
        initializeUpdateDifficultyDelegate ??= (param) => {
            InitializeUpdateDifficulty();
        };

        initiallizeResetUpdateDifficulty ??= (param) => {
            InitializeResetUpdateDifficulty();
        };

        Observer.AddListener(EventID.InitializeUpdateGame, initializeUpdateDifficultyDelegate);
        Observer.AddListener(EventID.InitializeResetUpdateGame, initiallizeResetUpdateDifficulty);
    }

    //Thực hiện việc tính toán độ khó
    protected virtual void InitializeUpdateDifficulty() {
        canCalculate = true;
        StartCoroutine(C_CalculateGameDifficulty());
    }

    //Thực hiện việc reset độ khó sau đó mới bắt đầu tính toán độ khó
    protected virtual void InitializeResetUpdateDifficulty(){
        canCalculate = true;
        StartCoroutine(C_ResetUpdateGameDifficulty());
    }

    //Tạm dừng việc tính toán độ khó hoặc việc reset độ khó
    protected virtual void PauseUpdateGameDifficulty() {
        canCalculate = false;
    }

    //Hàm abstract định nghĩa logic của việc tính đoán độ khó
    protected abstract IEnumerator C_CalculateGameDifficulty();

    //Hàm abstract định nghĩa logic của việc reset độ khó
    protected abstract IEnumerator C_ResetUpdateGameDifficulty();

    protected virtual bool CheckCanUpdateDifficulty() {
        return canCalculate && currentTime <= maxTimeToCalculate;
    }

    protected virtual bool CheckCanResetUpdateDifficulty(){
        return canCalculate && currentTime > 0;
    }
}