using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByStaticPointYoyoLoop that creates a yoyo movement trajectory loop for D_Obstacle Cube.
/// </summary>
public class D_ObstacleCubeMoveByPointYoyoLoop : ObjMoveByStaticPointYoyoLoop
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<ObstacleCubeCtrl>();
    }

    protected override void SetObjMovementConfig()
    {
        objMovementConfig = ((D_ObstacleCubeConfig)((ObstacleCubeCtrl)GetObjCtrl()).obstacleCubeConfig).D_ObstacleCubeMovementConfig;
        base.SetObjMovementConfig();
    }
}