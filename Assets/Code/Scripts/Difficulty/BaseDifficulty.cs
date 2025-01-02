using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDifficulty : ButMonobehavior
{
    [Header("BaseDifficulty")]
    protected float currentTime;
    protected static float maxTimeToCalculate;

    protected override void LoadValue() {
        base.LoadValue();

        currentTime = 0f;
    }

    protected virtual void Update() {
        if(CheckCanUpdateDifficulty()) UpdatingGameDifficulty();
        
        else if(CheckCanResetDifficulty()) ResetingGameDifficulty();
    }

    protected abstract void UpdatingGameDifficulty();

    protected abstract void ResetingGameDifficulty();

    protected virtual bool CheckCanUpdateDifficulty() {
        return GameManager.Instance.CurrentGameState.Equals(GameState.Running) && currentTime <= maxTimeToCalculate;
    }

    protected virtual bool CheckCanResetDifficulty(){
        return GameManager.Instance.CurrentGameState.Equals(GameState.Restarting) && currentTime > 0;
    }
}