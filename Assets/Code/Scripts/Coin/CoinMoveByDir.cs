using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByDir that define coin is moved by dir.
/// </summary>
public class CoinMoveByDir : ObjMoveByDir
{    
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<CoinCtrl>();
    }

    protected override void SetObjMovementConfig()
    {
        objMovementConfig = ((CoinCtrl)GetObjCtrl()).coinConfig.CoinMovementConfig;
    }
}