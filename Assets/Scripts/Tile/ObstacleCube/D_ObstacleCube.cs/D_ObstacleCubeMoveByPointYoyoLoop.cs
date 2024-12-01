using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByStaticPointYoyoLoop that creates a yoyo movement trajectory loop for D_Obstacle Cube.
/// </summary>
public class D_ObstacleCubeMoveByPointYoyoLoop : ObjMoveByStaticPointYoyoLoop
{
    protected override void LoadValue()
    {
        base.LoadValue();
        moveSpeed = ((D_ObstacleCubeConfig)((D_ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig).InitialMoveSpeed;
        spawnPoint = ((D_ObstacleCubeConfig)((D_ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig).InitialSpawnPoint;
        targetPoint = ((D_ObstacleCubeConfig)((D_ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig).InitialTargetPoint;
        remainingLoops = ((D_ObstacleCubeConfig)((D_ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig).InitialRemainingLoops;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<ObstacleCubeCtrl>();
    }
}