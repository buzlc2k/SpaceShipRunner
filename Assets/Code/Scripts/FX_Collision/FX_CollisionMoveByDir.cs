using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByDir that define FX_Collision is moved by dir.
/// </summary>
public class FX_CollisionMoveByDir : ObjMoveByDir
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