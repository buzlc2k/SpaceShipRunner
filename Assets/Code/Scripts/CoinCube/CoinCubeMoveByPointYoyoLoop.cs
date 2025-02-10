using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByStaticPointYoyoLoop that creates a yoyo movement trajectory loop for coin Cube.
/// </summary>
public class CoinCubeMoveByPointYoyoLoop : ObjMoveByStaticPointYoyoLoop
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<CoinCubeCtrl>();
    }

    protected override void SetObjMovementConfig()
    {
        objMovementConfig = ((CoinCubeCtrl)GetObjCtrl()).coinCubeConfig.CoinCubeMovementConfig;
        base.SetObjMovementConfig();
    }
}