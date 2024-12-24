using UnityEngine;

/// <summary>
/// Derived class from ObjMoveForward that define FX_Collision is moved foward a target.
/// </summary>
public class FX_CollisionMoveByTargetTransform : ObjMoveByTargetTransform
{
    protected override void LoadValue(){
        base.LoadValue();

        moveSpeed = ((FX_CollisionCtrl)GetObjCtrl()).fxConfig.InitialMoveSpeed;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<FX_CollisionCtrl>();
    }
}