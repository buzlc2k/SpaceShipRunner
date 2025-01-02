using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrackingManager : Singleton<PointTrackingManager>
{
    private float currentPoint;

    #region Property

    public float CurrentPoint { get => currentPoint; }

    #endregion

    protected override void LoadValue()
    {
        base.LoadValue();

        currentPoint = 0;
    }

    private void Update() {
        if(CheckCanUpdatePoint()) UpdatePoint();
    }

    protected virtual bool CheckCanUpdatePoint(){
        return GameManager.Instance.CurrentGameState.Equals(GameState.Running) || GameManager.Instance.CurrentGameState.Equals(GameState.Restarting);
    }

    private void UpdatePoint(){
        currentPoint += 5 * Time.deltaTime * (1 + DifficultyManager.Instance.GameSpeedRate);
    }
}