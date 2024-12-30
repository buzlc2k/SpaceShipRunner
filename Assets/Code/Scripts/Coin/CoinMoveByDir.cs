using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByDir that define coin is moved by dir.
/// </summary>
public class CoinMoveByDir : ObjMoveByDir
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