using UnityEngine;

/// <summary>
/// Derived class from ObjMoveForward that define obstacle tile is moved foward a target.
/// </summary>
public class ObstacleTileMoveByTargetTransform : ObjMoveByTargetTransform
{
    protected override void LoadValue(){
        base.LoadValue();

        moveSpeed = ((ObstacleTileCtrl)GetObjCtrl()).obstacleTileConfig.InitialMoveSpeed;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<ObstacleTileCtrl>();
    }
}