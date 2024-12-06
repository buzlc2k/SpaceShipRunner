using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByStaticPointYoyoLoop that creates a yoyo movement trajectory loop for coin Cube.
/// </summary>
public class CoinCubeMoveByPointYoyoLoop : ObjMoveByStaticPointYoyoLoop
{
    protected override void LoadValue()
    {
        base.LoadValue();

        moveSpeed = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialMoveSpeed;
        spawnPoint = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialSpawnPoint;
        targetPoint = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialTargetPoint;
        remainingLoops = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.InitialRemainingLoops;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<CoinCubeCtrl>();
    }
}