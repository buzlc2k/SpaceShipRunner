using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByDir that define FX_Collision is moved by dir.
/// </summary>
public class WorldVFXMoveByDir : ObjMoveByDir
{
    protected override object GetObjCtrl()
    {
        return transform.parent.GetComponent<WorldVFXCtrl>();
    }

    protected override void SetObjMovementConfig()
    {
        objMovementConfig = ((WorldVFXConfig)((WorldVFXCtrl)GetObjCtrl()).vfxConfig).VFXMovementConfig;
    }
}