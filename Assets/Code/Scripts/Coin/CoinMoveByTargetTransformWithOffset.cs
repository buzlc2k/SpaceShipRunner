using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByTargetTransformWithOffset that define coin is moved foward a target with offset.
/// </summary>
public class CoinMoveByTargetTransformWithOffset : ObjMoveByTargetTransformWithOffset
{
    protected override void LoadValue()
    {
        base.LoadValue();

        moveSpeed = ((CoinCtrl)GetObjCtrl()).coinConfig.InitialMoveSpeed;
    }
    
    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<CoinCtrl>();
    }
}