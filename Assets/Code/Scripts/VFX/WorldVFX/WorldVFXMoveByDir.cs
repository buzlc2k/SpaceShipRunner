using UnityEngine;

/// <summary>
/// Derived class from ObjMoveByDir that define FX_Collision is moved by dir.
/// </summary>
public class WorldVFXMoveByDir : ObjMoveByDir
{
    protected override void LoadValue(){
        base.LoadValue();

        moveSpeed = ((WorldVFXConfig)((WorldVFXCtrl)GetObjCtrl()).vfxConfig).InitialMoveSpeed;
    }

    protected override object GetObjCtrl()
    {
        return this.transform.parent.GetComponent<WorldVFXCtrl>();
    }
}