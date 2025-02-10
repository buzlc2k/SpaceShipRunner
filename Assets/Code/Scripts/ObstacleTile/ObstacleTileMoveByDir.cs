using UnityEngine;

/// <summary>
/// Derived class from ObjMoveForward that define obstacle tile is moved foward a target.
/// </summary>
public class ObstacleTileMoveByDir : ObjMoveByDir
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<ObstacleTileCtrl>();
    }

    protected override void SetObjMovementConfig()
    {
        objMovementConfig = ((ObstacleTileCtrl)GetObjCtrl()).obstacleTileConfig.ObstacleTileMovementConfig;
    }
}